---
title: C++ を使用したプレゼンテーションのビデオフレーム管理
linktitle: ビデオフレーム
type: docs
weight: 10
url: /ja/cpp/video-frame/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument スライドでビデオフレームをプログラムで追加および抽出する方法を学びます。高速ハウツーガイドです。"
---
## **はじめに**

プレゼンテーションに適切に配置されたビデオは、メッセージをより説得力のあるものにし、オーディエンスとのエンゲージメントレベルを高めることができます。

PowerPoint では、プレゼンテーションのスライドにビデオを追加する方法が2つあります。

* ローカルビデオを追加または埋め込む（マシンに保存されている）
* オンラインビデオを追加する（YouTube などのウェブソースから）。

プレゼンテーションにビデオ（ビデオオブジェクト）を追加できるように、Aspose.Slides は [IVideo](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ivideo/) インターフェイス、[IVideoFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ivideoframe/) インターフェイス、およびその他の関連型を提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオファイルがローカルに保存されている場合、プレゼンテーションにビデオを埋め込むビデオフレームを作成できます。

1. [Presentation ](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. [IVideo](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ivideo/) オブジェクトを追加し、ビデオファイルのパスを渡してプレゼンテーションにビデオを埋め込みます。
1. [IVideoFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ivideoframe/) オブジェクトを追加してビデオのフレームを作成します。
1. 変更されたプレゼンテーションを保存します。

この C++ コードは、ローカルに保存されたビデオをプレゼンテーションに追加する方法を示しています。

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// Loads the video
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// Gets the first slide and adds a videoframe
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// Saves the presentation to disk
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```

または、ビデオのファイルパスを直接 [AddVideoFrame()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapecollection/addvideoframe/) メソッドに渡すことでビデオを追加できます。

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **Web ソースからのビデオでビデオフレームを作成する**

Microsoft の新しいバージョンの [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) は、プレゼンテーションでオンラインビデオをサポートしています。使用したいビデオがオンライン（例：YouTube）で利用可能な場合、そのウェブリンクを介してプレゼンテーションに追加できます。

1. [Presentation ](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. [IVideo](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ivideo/) オブジェクトを追加し、ビデオへのリンクを渡します。
1. ビデオフレームのサムネイルを設定します。
1. プレゼンテーションを保存します。

この C++ コードは、Web からビデオを取得して PowerPoint プレゼンテーションのスライドに追加する方法を示しています。

```c++
// ドキュメントディレクトリへのパスです。
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセスします
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// ビデオフレームを追加します 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// ビデオの再生モードと音量を設定します
vf->set_PlayMode(VideoPlayModePreset::Auto);

//プレゼンテーションをディスクに保存します
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **ビデオフレームのトリミング**

Aspose.Slides は、[IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ivideoframe/set_trimfromstart/) および [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ivideoframe/set_trimfromend/) を使用して trim‑from‑start と trim‑from‑end の値を設定することで、ビデオのどの部分を再生するかを制御できます。両方の値はミリ秒で指定され、ビデオの開始点と終了点からそれぞれどれだけの時間をスキップするかを定義します。この設定はプレゼンテーション内のビデオ再生設定を変更しますが、埋め込まれたビデオのバイナリデータをカットしたり変更したりはしません。

**トリム設定の設定**

ビデオフレームを作成し、トリム設定を行うには：

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [IVideo](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ivideo/) オブジェクトをプレゼンテーションに追加します。
1. [IVideoFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ivideoframe/) オブジェクトをスライドに追加します。
1. [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ivideoframe/set_trimfromstart/) と [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ivideoframe/set_trimfromend/) を使用して trim‑from‑start と trim‑from‑end の値を設定します。
1. 変更されたプレゼンテーションを保存します。

以下のコード例は、埋め込みビデオの再生時に最初の 2.5 秒と最後の 1 秒をスキップします。

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 640, 360, video);

videoFrame->set_TrimFromStart(2500.0f);
videoFrame->set_TrimFromEnd(1000.0f);

presentation->Save(u"video_with_trim.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**トリム設定の読み取り**

既存のトリム設定を確認するには、プレゼンテーションを読み込み、最初のスライド上のシェイプの中から [IVideoFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ivideoframe/) オブジェクトを見つけ、[IVideoFrame::get_TrimFromStart](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ivideoframe/get_trimfromstart/) および [IVideoFrame::get_TrimFromEnd](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ivideoframe/get_trimfromend/) で値を取得します。

以下のコード例は、最初のスライド上の最初のビデオフレームを見つけ、そのトリム設定（ミリ秒単位）を報告します。

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_trim.pptx");

auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        auto trimFromStart = videoFrame->get_TrimFromStart();
        auto trimFromEnd = videoFrame->get_TrimFromEnd();

        Console::WriteLine(u"Trim from start: {0} ms", trimFromStart);
        Console::WriteLine(u"Trim from end: {0} ms", trimFromEnd);

        break;
    }
}

presentation->Dispose();
```

## **ビデオキャプションの管理**

Aspose.Slides は、PowerPoint プレゼンテーションのビデオフレームに対してクローズドキャプションを管理できるようにします。キャプションは WebVTT 形式で保存され、[IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ivideoframe/get_captiontracks/) メソッドを通じて取得できます。

**ビデオフレームにキャプションを追加する**

ビデオフレームにキャプションを追加するには：

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. プレゼンテーションにビデオを追加します。
1. [IVideoFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ivideoframe/) オブジェクトをスライドに追加します。
1. [get_CaptionTracks](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ivideoframe/get_captiontracks/) が返す [ICaptionsCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icaptionscollection/) を使用して WebVTT キャプショントラックを追加します。
1. 変更されたプレゼンテーションを保存します。

以下のコードは、ビデオフレームにキャプションを追加する方法を示しています。

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// WebVTT ファイルから新しいキャプショントラックを追加します。
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[ICaptionsCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icaptionscollection/) インターフェイスは、ストリームからキャプションを追加できるオーバーロードも提供します。

**ビデオフレームからキャプションを抽出する**

ビデオフレームからキャプションを抽出するには：

1. ビデオを含むプレゼンテーションを読み込みます。
1. 対象の [IVideoFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ivideoframe/) オブジェクトを見つけます。
1. [get_CaptionTracks](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ivideoframe/get_captiontracks/) が返すキャプショントラックを列挙します。
1. 各キャプショントラックを `.vtt` ファイルとして保存します。

以下のコードは、ビデオフレームからキャプションを抽出する方法を示しています。

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        for (auto&& captionTrack : videoFrame->get_CaptionTracks())
        {
            // キャプショントラックを WebVTT ファイルに保存します。
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

各 [ICaptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icaptions/) オブジェクトは、キャプション識別子、ラベル、バイナリデータ、および UTF‑8 文字列としてのキャプションデータを公開します。

**ビデオフレームからキャプションを削除する**

ビデオフレームからキャプションを削除するには：

1. ビデオを含むプレゼンテーションを読み込みます。
1. 対象の [IVideoFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ivideoframe/) オブジェクトを取得します。
1. [get_CaptionTracks](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ivideoframe/get_captiontracks/) が返すコレクションからキャプショントラックを削除します。
1. 変更されたプレゼンテーションを保存します。

以下のコードは、ビデオフレームからすべてのキャプションを削除する方法を示しています。

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// ビデオフレームからすべてのキャプションを削除します。
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

1 つだけキャプショントラックを削除したい場合は、[Clear](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icaptionscollection/clear/) の代わりに [Remove](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icaptionscollection/remove/) または [RemoveAt](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icaptionscollection/removeat/) メソッドを使用してください。

## **スライドからビデオを抽出する**

スライドにビデオを追加するだけでなく、Aspose.Slides はプレゼンテーションに埋め込まれたビデオを抽出することも可能です。

1. ビデオを含むプレゼンテーションを読み込むために、[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. すべての [ISlide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islide/) オブジェクトを列挙します。
3. すべての [IShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/) オブジェクトを列挙し、[VideoFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/videoframe/) を見つけます。
4. ビデオをディスクに保存します。

この C++ コードは、プレゼンテーションのスライド上のビデオを抽出する方法を示しています。

```c++
// ドキュメントディレクトリへのパスです。
const System::String templatePath = u"../templates/Video.pptx";
const System::String outPath = u"../out/Video_out";

auto presentation = System::MakeObject<Presentation>(templatePath);
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        if (System::ObjectExt::Is<VideoFrame>(shape))
        {
            System::SharedPtr<VideoFrame> vf = System::AsCast<VideoFrame>(shape);
            System::String type = vf->get_EmbeddedVideo()->get_ContentType();
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            auto buffer = vf->get_EmbeddedVideo()->get_BinaryData();

            auto stream = System::MakeObject<System::IO::FileStream>(
                outPath + type, System::IO::FileMode::Create, System::IO::FileAccess::Write,
                System::IO::FileShare::Read);
            stream->Write(buffer, 0, buffer->get_Length());
        }
    }
}
```

## **FAQ**

**VideoFrame の再生パラメータで変更できるものは何ですか？**

再生モード（自動またはクリック時）とループ設定は、[playback mode](https://reference.aspose.com/slides/ja/cpp/aspose.slides/videoframe/set_playmode/) と [looping](https://reference.aspose.com/slides/ja/cpp/aspose.slides/videoframe/set_playloopmode/) を使用して制御できます。これらのオプションは、[VideoFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/videoframe/) オブジェクトのプロパティから利用できます。

**ビデオを追加すると PPTX ファイルサイズに影響しますか？**

はい。ローカルビデオを埋め込むと、バイナリデータがドキュメントに含まれるため、プレゼンテーションのサイズはファイルサイズに比例して増加します。オンラインビデオを追加すると、リンクとサムネイルが埋め込まれるだけなので、サイズ増加は小さくなります。

**既存の VideoFrame のビデオを、位置やサイズを変更せずに置き換えることはできますか？**

はい。フレーム内の [video content](https://reference.aspose.com/slides/ja/cpp/aspose.slides/videoframe/set_embeddedvideo/) を入れ替えることで、シェイプの形状を保ったままビデオを置き換えることができます。これは既存のレイアウトでメディアを更新する一般的なシナリオです。

**埋め込まれたビデオのコンテンツタイプ（MIME）を取得できますか？**

はい。埋め込まれたビデオには [content type](https://reference.aspose.com/slides/ja/cpp/aspose.slides/video/get_contenttype/) が設定されており、これを読み取って使用できます。たとえばディスクに保存する際などに利用できます。