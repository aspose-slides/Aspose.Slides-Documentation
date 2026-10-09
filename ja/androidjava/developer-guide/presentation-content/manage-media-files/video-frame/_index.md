---
title: Android でのプレゼンテーションにおけるビデオフレームの管理
linktitle: ビデオフレーム
type: docs
weight: 10
url: /ja/androidjava/video-frame/
keywords:
- ビデオを追加
- ビデオを作成
- ビデオを埋め込む
- ビデオを抽出
- ビデオを取得
- ビデオフレーム
- Web ソース
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint および OpenDocument スライドでビデオフレームをプログラムで追加および抽出する方法を学べます。高速ハウツーガイド。"
---
## **はじめに**

動画は、アイデアの説明やオーディエンスの関心を引くのに役立ちます。Aspose.Slides for Android via Java を使用すると、スライドにビデオフレームを追加し、再生設定を調整し、キャプションを管理し、埋め込みビデオデータを抽出できます。

PowerPoint はローカルのビデオと、YouTube 動画などのオンラインビデオへのリンクをサポートしています。

動画データと動画フレームを表すために、Aspose.Slides は [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) インターフェイス、[IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) インターフェイス、およびその他の関連型を提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオファイルがローカルに保存されている場合、ビデオフレームを作成してプレゼンテーションにビデオを埋め込むことができます。

この例は、既存のプレゼンテーションの最初のスライドにローカルビデオを埋め込み、結果を保存します。フレームの座標とサイズはポイント単位です。ストリームは保存が完了するまで開いたままになり、[LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadingstreambehavior/) がプレゼンテーションで使用中ロックを保持するためです。

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.KeepLocked);
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

    presentation.save("embedded_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ローカルビデオのパスを直接 [addVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-) に渡すこともできます。この例は、新しいプレゼンテーションの最初のスライドにビデオを埋め込みます。ビデオはプレゼンテーションが保存されるまでアクセス可能である必要があります。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Web ソースからのビデオでビデオフレームを作成する**

Microsoft の [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) はプレゼンテーションでオンラインビデオをサポートしています。YouTube 動画などのオンラインビデオへのリンクを持つビデオフレームを作成できます。

この例は、最初のスライドに YouTube ビデオのリンクとサムネイルを追加します。別のビデオを使用する場合はビデオ ID を置き換えてください。[setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setPlayMode-int-) メソッドは自動再生を要求します。サムネイルの取得とビデオの再生にはインターネット接続が必要です。また、プレゼンテーションビューアがオンラインビデオの再生に対応している必要があります。

```java
import com.aspose.slides.*;
import java.io.InputStream;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    String videoId = "aqz-KE-bpKQ";
    String videoUrl = "https://www.youtube.com/embed/" + videoId;
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    String thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    URL thumbnailLocation = new URL(thumbnailUrl);
    try (InputStream thumbnailStream = thumbnailLocation.openStream()) {
        IPPImage thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    }

    presentation.save("online_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **全画面モードでビデオを再生する**

トレーニング用プレゼンテーションでは、ソフトウェアデモを全画面モードで再生して詳細を見せることができます。再生中にこの動作を有効にするには、`true` を指定して [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) を呼び出します。

この例はプレゼンテーションを開き、最初のスライド上の最初の [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) を見つけて全画面再生を有効にします。入力プレゼンテーションには、最初のスライドに既存のビデオフレームが少なくとも1つ含まれている必要があります。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

全画面再生はビデオの表示方法を制御します。別途、[setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) は自動開始かクリック開始かを、[setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) はループの有無を制御します。開始動作を選択するには、再生モードを [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) に設定します。サンプルは既存の開始設定とループ設定を保持します。

## **再生後にビデオを巻き戻す**

トレーニング用プレゼンテーションで、デモビデオを最初に戻すことで、プレゼンターが再度再生できるようになります。再生が完了した後にビデオを最初に戻すには、`true` を指定して [setRewindVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setRewindVideo-boolean-) を呼び出します。

この例はプレゼンテーションを開き、最初のスライド上の最初の [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) を見つけて巻き戻しを有効にします。ループを無効にして再生が終了できるようにし、開始はクリック時に設定します。入力プレゼンテーションには、最初のスライドに既存のビデオフレームが少なくとも1つ含まれている必要があります。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

巻き戻しはビデオを最初に戻しますが、再度自動的に開始はしません。対照的に、[setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) に `true` を設定すると再生が自動的に繰り返されます。ビデオを最後まで再生させてから再度再生できる状態にしたい場合はループを無効にしてください。[setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) は自動開始かクリック開始かを個別に制御します。この例では [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) を使用し、プレゼンターが再生開始を制御できるようにしています。ループ設定の後に再生モードを設定してください。巻き戻しは [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) の設定とは独立して動作します。

## **ビデオフレームをトリミングする**

[IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) と [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) を使用して、再生時にビデオの開始部または終了部をスキップできます。両方の値はミリ秒単位です。トリミングは埋め込みビデオデータを変更せずに再生設定だけを変更します。

**トリム設定の適用**

この例はローカルビデオを埋め込み、再生時に最初の 2.5 秒と最後の 1 秒をスキップします。再生可能なセグメントが残るように、ビデオは 3.5 秒以上の長さである必要があります。

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**トリム設定の取得**

この例は最初のスライド上の最初のビデオフレームのトリム値をミリ秒で出力します。プレゼンテーションに少なくとも1枚のスライドが必要です。そのスライドにビデオフレームが無い場合は何も出力されません。前の例では 2500 と 1000 が出力されます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            System.out.println("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            System.out.println("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **ビデオキャプションの管理**

Aspose.Slides は PowerPoint プレゼンテーションのビデオフレームに対してクローズドキャプションを管理できる機能を提供します。キャプションは WebVTT 形式で保存され、[IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) メソッドで取得できます。

**ビデオフレームにキャプションを追加する**

この例はローカルビデオを埋め込み、ラベルが English の WebVTT キャプショントラックを追加します。キャプションのタイムスタンプはビデオに合わせてください。保存されたプレゼンテーションにはビデオとキャプションの両方が含まれます。

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ICaptionsCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/) インターフェイスは、ストリームからキャプションを追加できるオーバーロードも提供します。

**ビデオフレームからキャプションを抽出する**

この例は最初のスライド上のビデオフレームからすべてのキャプショントラックを個別の WebVTT ファイルとして保存します。連番で出力ファイルを区別します。コンソールには抽出されたトラック数が表示されます。プレゼンテーションには少なくとも1枚のスライドが必要です。

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                try (FileOutputStream outputStream = new FileOutputStream("captions_" + trackCount + ".vtt")) {
                    outputStream.write(captionTrack.getBinaryData());
                }
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

各 [ICaptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/) オブジェクトはキャプションの識別子、ラベル、バイナリデータ、UTF-8 文字列としてのキャプションテキストを公開します。

**ビデオフレームからキャプションを削除する**

この例は最初のスライド上の最初のシェイプ位置にあるビデオフレームからすべてのキャプションを削除し、結果を保存します。スライドとシェイプが存在し、シェイプがビデオフレームであることを前提としています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

1 つのキャプショントラックだけを削除したい場合は、[clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#clear--) の代わりに [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) または [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#removeAt-int-) メソッドを使用してください。

## **スライドからビデオを抽出する**

ビデオをスライドに追加するだけでなく、Aspose.Slides はプレゼンテーションに埋め込まれたビデオを抽出することも可能です。

この例は各スライドから埋め込みビデオを個別の番号付きバイナリファイルとして抽出します。リンクされたビデオは埋め込みデータが無いためスキップされます。コンソールには各ビデオの MIME タイプと総数が出力されます。出力ファイルは汎用的な `.bin` 拡張子を使用しますが、必要に応じて報告されたメディアタイプに合わせて変更してください。

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation_with_videos.pptx");
try {
    int videoCount = 0;
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                IVideoFrame videoFrame = (IVideoFrame) shape;
                IVideo video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    System.out.println("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                try (FileOutputStream outputStream = new FileOutputStream("extracted_video_" + videoCount + ".bin")) {
                    outputStream.write(video.getBinaryData());
                }
                System.out.println("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    System.out.println("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **よくある質問**

**ビデオフレームで変更できる再生パラメータは何ですか？**

[playback mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-)（自動またはクリック）と [looping](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) を制御できます。これらのオプションは [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/) オブジェクトのメソッドで利用可能です。

**ビデオを追加すると PPTX ファイルのサイズは増えますか？**

はい。ローカルビデオを埋め込むと、バイナリデータがドキュメントに含まれるため、プレゼンテーションのサイズはビデオファイルのサイズに比例して増加します。オンラインビデオへのリンクとサムネイルだけを追加した場合は、ビデオデータは保存されないため、サイズ増加は通常小さくなります。

**既存のビデオフレームの位置やサイズを変えずにビデオを差し替えることはできますか？**

はい。フレーム内の [video content](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) を入れ替えることで、シェイプのジオメトリを保持したままビデオを更新できます。これは既存レイアウトのメディアを更新する一般的なシナリオです。

**埋め込みビデオのコンテンツタイプ（MIME）を取得できますか？**

はい。埋め込みビデオには [content type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--) があり、これを読み取って保存先の拡張子選択などに利用できます。