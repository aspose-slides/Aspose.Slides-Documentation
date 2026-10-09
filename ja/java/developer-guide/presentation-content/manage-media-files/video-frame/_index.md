---
title: Java を使用したプレゼンテーションでのビデオフレームの管理
linktitle: ビデオフレーム
type: docs
weight: 10
url: /ja/java/video-frame/
keywords:
- ビデオを追加
- ビデオを作成
- ビデオを埋め込み
- ビデオを抽出
- ビデオを取得
- ビデオフレーム
- ウェブソース
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument スライドでビデオフレームをプログラム的に追加および抽出する方法を学びます。高速ハウツーガイド。"
---
## **はじめに**

動画はアイデアの説明やオーディエンスの関心を引くのに役立ちます。Aspose.Slides for Java を使用すると、スライドにビデオフレームを追加し、再生設定を調整し、キャプションを管理し、埋め込まれたビデオデータを抽出できます。

PowerPoint はローカルビデオと、YouTube ビデオなどのオンラインビデオへのリンクをサポートしています。

ビデオデータとビデオフレームを表すために、Aspose.Slides は [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) インターフェイス、[IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) インターフェイス、およびその他の関連型を提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオファイルがローカルに保存されている場合、ビデオフレームを作成してプレゼンテーションにビデオを埋め込むことができます。

この例は、既存のプレゼンテーションの最初のスライドにローカルビデオを埋め込み、結果を保存します。フレームの座標とサイズはポイント単位です。ストリームは保存が完了するまで開いたままになり、[LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/java/com.aspose.slides/loadingstreambehavior/) がプレゼンテーションが使用中にロックを保持します。

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

ローカルビデオのパスを直接 [addVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-) に渡すこともできます。この例は、新しいプレゼンテーションの最初のスライドにビデオを埋め込みます。ビデオはプレゼンテーションが保存されるまでアクセス可能である必要があります。

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

## **Web ソースからのビデオでビデオフレームを作成**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) はプレゼンテーションでオンラインビデオをサポートしています。YouTube ビデオなどのオンラインビデオへのリンクを持つビデオフレームを作成できます。

この例は、YouTube ビデオのリンクとサムネイルを最初のスライドに追加します。別のビデオを使用する場合はビデオ識別子を置き換えてください。[setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setPlayMode-int-) メソッドは自動再生を要求します。サムネイルのダウンロードとビデオの再生にはインターネット接続が必要です。プレゼンテーションビューアもオンラインビデオ再生をサポートしている必要があります。

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

## **全画面モードでビデオを再生**

トレーニング用プレゼンテーションでは、ソフトウェアのデモを全画面モードで再生して、観客に詳細を見せることができます。再生中にこの動作を有効にするには、`true` を渡して [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) を呼び出します。

この例はプレゼンテーションを開き、最初のスライドの最初の [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) を見つけ、全画面再生を有効にします。入力プレゼンテーションには、最初のスライドに既存のビデオフレームが少なくとも 1 つ含まれている必要があります。

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

全画面再生はビデオの表示方法を制御します。別途、[setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) は自動開始かクリック開始かを、[setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) はループするかどうかを制御します。開始動作を選択するには、再生モードを [VideoPlayModePreset.Auto または VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) に設定します。この例は既存の開始およびループ設定を保持します。

## **再生後にビデオを巻き戻す**

トレーニング用プレゼンテーションで、デモビデオを最初に戻すと、プレゼンターが再度再生できるようになります。再生終了後にビデオを先頭に戻すには、`true` を渡して [setRewindVideo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setRewindVideo-boolean-) を呼び出します。

この例はプレゼンテーションを開き、最初のスライドの最初の [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) を見つけ、巻き戻しを有効にします。ループを無効にして再生が完了できるようにし、クリックで開始するように再生モードを設定します。入力プレゼンテーションには、最初のスライドに既存のビデオフレームが少なくとも 1 つ含まれている必要があります。

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

巻き戻しはビデオを先頭に戻すだけで、再び自動的に開始しません。対照的に、`true` を渡して [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) を呼び出すと再生が自動的に繰り返されます。ビデオを最後まで再生させて再度再生できる状態にしたい場合は、ループを無効にしてください。[setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) は自動開始かクリック開始かを個別に制御します。この例では [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) を使用して、プレゼンターが再生開始を制御できるようにしています。ループ設定の後に再生モードを設定してください。巻き戻しは [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) とは独立して機能します。

## **ビデオフレームをトリミング**

[IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) と [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) を使用して、再生時にビデオの冒頭または末尾の一部をスキップできます。両方の値はミリ秒単位です。トリミングは埋め込まれたビデオデータを変更せずに再生設定を変更します。

**トリム設定の適用**

この例はローカルビデオを埋め込み、再生時に最初の 2.5 秒と最後の 1 秒をスキップします。再生可能なセグメントが残るように、3.5 秒以上のビデオを使用してください。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**トリム設定の取得**

この例は最初のスライドの最初のビデオフレームのトリム値をミリ秒で出力します。プレゼンテーションに少なくとも 1 枚のスライドが含まれている必要があります。そのスライドにビデオフレームがない場合は何も出力されません。前の例は 2500 と 1000 を出力します。

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

Aspose.Slides は PowerPoint プレゼンテーション内のビデオフレームに対してクローズドキャプションを管理できる機能を提供します。キャプションは WebVTT 形式で保存され、[IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) メソッドで取得できます。

**ビデオフレームにキャプションを追加**

この例はローカルビデオを埋め込み、英語というラベルの WebVTT キャプショントラックを追加します。キャプションのタイムスタンプはビデオと一致させる必要があります。保存されたプレゼンテーションにはビデオとキャプションの両方が含まれます。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) インターフェイスは、ストリームからキャプションを追加できるオーバーロードも提供します。

**ビデオフレームからキャプションを抽出**

この例は最初のスライド上のビデオフレームからすべてのキャプショントラックを個別の WebVTT ファイルとして保存します。連番で出力ファイルを区別します。コンソールは抽出されたトラック数を報告します。プレゼンテーションに少なくとも 1 枚のスライドが必要です。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                Path outputPath = Paths.get("captions_" + trackCount + ".vtt");
                Files.write(outputPath, captionTrack.getBinaryData());
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

各 [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/) オブジェクトはキャプション識別子、ラベル、バイナリデータ、UTF-8 文字列としてのキャプションテキストを公開します。

**ビデオフレームからキャプションを削除**

この例は最初のスライドの最初のシェイプ位置にあるビデオフレームからすべてのキャプションを削除し、結果を保存します。スライドとシェイプが存在し、シェイプがビデオフレームであることを前提としています。

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

1 つだけのキャプショントラックを削除したい場合は、[clear](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#clear--) の代わりに [remove](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) または [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#removeAt-int-) メソッドを使用してください。

## **スライドからビデオを抽出**

スライドにビデオを追加するだけでなく、Aspose.Slides はプレゼンテーションに埋め込まれたビデオを抽出することも可能です。

この例は各スライドから埋め込まれたビデオを個別の番号付きバイナリファイルに抽出します。リンクされたビデオは埋め込みデータがないためスキップされます。コンソールは各ビデオの MIME タイプと総数を出力します。出力は汎用の `.bin` 拡張子を使用します。必要に応じて報告されたメディアタイプに合わせて拡張子を変更してください。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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
                Path outputPath = Paths.get("extracted_video_" + videoCount + ".bin");
                Files.write(outputPath, video.getBinaryData());
                System.out.println("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    System.out.println("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**ビデオフレームで変更できる再生パラメータは何ですか？**

[playback mode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-)（自動またはクリック）と [looping](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) を制御できます。これらのオプションは [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/) オブジェクトのメソッドで利用可能です。

**ビデオを追加すると PPTX ファイルのサイズは増加しますか？**

はい。ローカルビデオを埋め込むと、バイナリデータがドキュメントに含まれるため、プレゼンテーションのサイズはビデオファイルのサイズに比例して大きくなります。オンラインビデオへのリンクとサムネイルだけを追加した場合は、ビデオデータ自体は保存されないため、サイズ増加は通常小さくなります。

**既存のビデオフレームの位置やサイズを変更せずにビデオを差し替えることはできますか？**

はい。フレーム内の [video content](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) を入れ替えることで、シェイプのジオメトリを保持したままビデオを更新できます。これは既存レイアウトのメディア更新によく使われます。

**埋め込みビデオのコンテンツタイプ（MIME）を取得できますか？**

はい。埋め込まれたビデオには [content type](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) があり、これを読み取ってたとえばディスクに保存する際に利用できます。