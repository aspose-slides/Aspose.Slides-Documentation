---
title: Java を使用したプレゼンテーション内のビデオフレーム管理
linktitle: ビデオフレーム
type: docs
weight: 10
url: /ja/java/video-frame/
keywords:
- ビデオの追加
- ビデオの作成
- ビデオの埋め込み
- ビデオの抽出
- ビデオの取得
- ビデオフレーム
- Web ソース
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument スライドにビデオフレームをプログラムで追加および抽出する方法を学びます。高速ハウツーガイド。"
---
## **導入**

ビデオはアイデアの説明や視聴者の関心を引くのに役立ちます。Aspose.Slides for Java を使用すると、スライドにビデオフレームを追加し、再生設定を調整し、キャプションを管理し、埋め込みビデオデータを抽出できます。

PowerPoint はローカルビデオと、YouTube ビデオなどのオンラインビデオへのリンクをサポートします。

ビデオデータとビデオフレームを表すために、Aspose.Slides は [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) インターフェイス、[IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) インターフェイス、その他の関連型を提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオファイルがローカルに保存されている場合、プレゼンテーションにビデオを埋め込むビデオフレームを作成できます。

この例は、既存のプレゼンテーションの最初のスライドにローカルビデオを埋め込み、結果を保存します。フレームの座標とサイズはポイント単位です。保存が完了するまでストリームは開いたままです。これは、[LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/java/com.aspose.slides/loadingstreambehavior/) がプレゼンテーションで使用されている間ストリームをロックしたままにするためです。

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

ローカルビデオのパスを直接 [addVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-) に渡すこともできます。この例は、新しいプレゼンテーションの最初のスライドにビデオを埋め込みます。ビデオはプレゼンテーションが保存されるまでアクセス可能な状態である必要があります。

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

Microsoft の [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) はプレゼンテーションでオンラインビデオをサポートします。YouTube ビデオなどのオンラインビデオへのリンクになるビデオフレームを作成できます。

この例は、最初のスライドに YouTube ビデオのリンクとサムネイルを追加します。別のビデオを使用するにはビデオ識別子を置き換えてください。[setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setPlayMode-int-) メソッドは自動再生を要求します。サムネイルのダウンロードとビデオの再生にはインターネット接続が必要です。プレゼンテーションビューアーもオンラインビデオの再生をサポートしている必要があります。

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

トレーニング用プレゼンテーションでは、ソフトウェアデモンストレーションを全画面モードで再生し、視聴者が詳細を確認できるようにできます。再生中にこの動作を有効にするには、`true` を指定して [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) を呼び出します。

この例はプレゼンテーションを開き、最初のスライドで最初の [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) を見つけ、全画面再生を有効にします。入力プレゼンテーションは、最初のスライドに既存のビデオフレームが少なくとも1つ含まれている必要があります。

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

全画面再生はビデオの表示方法を制御します。別途、[setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) は自動開始かクリック開始かを、[setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) は繰り返し再生するかどうかを制御します。開始動作を選択するには、再生モードを [VideoPlayModePreset.Auto または VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) に設定します。この例は既存の開始およびループ設定を保持します。

## **再生後にビデオを巻き戻す**

トレーニング用プレゼンテーションでは、デモビデオを最初に戻すことで、プレゼンターが再度再生できるようにします。再生が終了した後にビデオを最初に戻すには、`true` を指定して [setRewindVideo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setRewindVideo-boolean-) を呼び出します。

この例はプレゼンテーションを開き、最初のスライドで最初の [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) を見つけ、巻き戻しを有効にします。ループを無効にして再生が終了できるようにし、クリックで開始するように再生を設定します。入力プレゼンテーションは、最初のスライドに既存のビデオフレームが少なくとも1つ含まれている必要があります。

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

巻き戻しはビデオを再度開始せずに最初に戻します。対照的に、`true` を指定して [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) を呼び出すと再生が自動的に繰り返されます。ビデオを終了させ、再生準備状態にしておきたい場合はループを無効にしてください。[setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) は自動開始またはクリック開始を個別に制御します。この例では [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) を使用し、プレゼンターが再生開始タイミングを制御します。例示のとおり、ループ設定の後に再生モードを設定します。巻き戻しは [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) とは独立して機能します。

## **ビデオフレームのトリミング**

再生中にビデオの冒頭または末尾の一部をスキップするには、[IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) と [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) を使用します。両方の値はミリ秒単位です。トリミングは埋め込みビデオデータを変更せずに再生設定を変更します。

**トリム設定**

この例はローカルビデオを埋め込み、再生時に最初の 2.5 秒と最後の 1 秒をスキップします。再生可能なセグメントが残るよう、3.5 秒以上のビデオを使用してください。

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

この例は、最初のスライド上の最初のビデオフレームのトリム値をミリ秒単位で出力します。プレゼンテーションは少なくとも1枚のスライドを含んでいる必要があります。そのスライドにビデオフレームがない場合は何も出力されません。前の例では 2500 と 1000 の値が生成されます。

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

Aspose.Slides は PowerPoint プレゼンテーション内のビデオフレームのクローズドキャプションを管理できるようにします。キャプションは WebVTT 形式で保存され、[IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) メソッドで取得できます。

### **ビデオフレームにキャプションを追加**

この例はローカルビデオを埋め込み、"English" とラベル付けされた WebVTT キャプショントラックを追加します。キャプションのタイムスタンプはビデオに合わせる必要があります。保存されたプレゼンテーションにはビデオとキャプションの両方が含まれます。

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

### **ビデオフレームからキャプションを抽出**

この例は、最初のスライド上のビデオフレームからすべてのキャプショントラックを個別の WebVTT ファイルとして保存します。連番により出力ファイルが区別されます。コンソールは抽出されたトラック数を報告します。プレゼンテーションは少なくとも1枚のスライドを含んでいる必要があります。

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

各 [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/) オブジェクトは、キャプション識別子、ラベル、バイナリデータ、および UTF-8 文字列としてのキャプションテキストを公開します。

### **ビデオフレームからキャプションを削除**

この例は、最初のスライドの最初のシェイプ位置にあるビデオフレームからすべてのキャプションを削除し、結果を保存します。スライドとシェイプが存在し、シェイプがビデオフレームであることを前提としています。

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

1つのキャプショントラックだけを削除したい場合は、[clear](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#clear--) の代わりに [remove](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) または [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#removeAt-int-) メソッドを使用してください。

### **ビデオキャプションを検索**

[ICaptions.getDataAsString](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getDataAsString--) はヘッダー、タイミング行、キャプションテキストを含む完全な WebVTT トラックを返します。メモリ内のキューを検索して、話されたフレーズとそのタイムスタンプを見つけることができます。例えば、スライド 2 の英語トラックには次のテキストが含まれるかもしれません。

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

この例は `captioned_media.pptx` を開き、[IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) を使用して各スライド上のトップレベルビデオフレームのトラックを読み取ります。プレーンテキストのキューでは、タイミング行に `-->` が含まれ、空行でキューが終了します。キャプションに大文字小文字を問わず “café” が含まれると、例はスライド番号、トラックラベル、元のタイミング行、完全なキャプションを出力します。

```java
import com.aspose.slides.*;
import java.util.Locale;
import java.util.Scanner;
import java.util.StringJoiner;

Presentation presentation = new Presentation("captioned_media.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IVideoFrame)) {
                continue;
            }
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions track : videoFrame.getCaptionTracks()) {
                try (Scanner reader = new Scanner(track.getDataAsString())) {
                    while (reader.hasNextLine()) {
                        String timing = reader.nextLine();
                        if (!timing.contains("-->")) {
                            continue;
                        }
                        StringJoiner caption = new StringJoiner(System.lineSeparator());
                        while (reader.hasNextLine()) {
                            String line = reader.nextLine();
                            if (line.isEmpty()) {
                                break;
                            }
                            caption.add(line);
                        }
                        if (caption.toString().toLowerCase(Locale.ROOT).contains("café")) {
                            System.out.printf("Slide %d | %s | %s%n", slide.getSlideNumber(), track.getLabel(), timing);
                            System.out.println(caption);
                        }
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

“café” を検索するとサンプルトラックで1件の一致が得られます。検索はトラックヘッダーを除外し、出力ではタイミング設定を保持します。

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **スライドからビデオを抽出**

スライドへビデオを追加するだけでなく、Aspose.Slides はプレゼンテーションに埋め込まれたビデオを抽出することもできます。

この例は、すべてのスライドから埋め込みビデオを個別の番号付きバイナリファイルに抽出します。リンクされたビデオは埋め込みデータがないためスキップされます。コンソールは各ビデオの MIME タイプと総数を出力します。出力は汎用の `.bin` 拡張子を使用します。必要に応じて報告されたメディアタイプに合わせて拡張子を変更してください。

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

**ビデオフレームの再生パラメーターで変更できるものは何ですか？**

再生モード（自動またはクリック）と[ループ](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) を制御できます。これらのオプションは、[再生モード](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) と [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/) オブジェクトのメソッドで利用可能です。

**ビデオを追加すると PPTX ファイルサイズに影響がありますか？**

はい。ローカルビデオを埋め込むと、バイナリデータがドキュメントに含まれるため、プレゼンテーションのサイズはビデオファイルのサイズに比例して増加します。オンラインビデオへのリンクとサムネイルを追加する場合、プレゼンテーションはビデオデータではなくリンクとプレビュー画像を保存するため、サイズの増加は通常は小さくなります。

**既存のビデオフレームの位置やサイズを変更せずにビデオを差し替えることはできますか？**

はい。フレーム内の[ビデオコンテンツ](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) を交換し、シェイプの形状を保持したまま変更できます。これは既存のレイアウトでメディアを更新する一般的なシナリオです。

**埋め込みビデオのコンテンツタイプ（MIME）を取得できますか？**

はい。埋め込みビデオは[コンテンツタイプ](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) を持ち、これを読み取って使用できます。たとえばディスクに保存する際に利用できます。