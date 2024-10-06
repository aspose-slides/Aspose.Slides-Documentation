---
title: ビデオフレーム
type: docs
weight: 10
url: /ja/cpp/video-frame/
keywords: "ビデオを追加, ビデオフレームを作成, ビデオを抽出, PowerPointプレゼンテーション, C++, CPP, Aspose.Slides for C++"
description: "C++でPowerPointプレゼンテーションにビデオフレームを追加する"

---

プレゼンテーションに適切に配置されたビデオは、メッセージをより魅力的にし、聴衆とのエンゲージメントレベルを高めることができます。

PowerPointでは、プレゼンテーションのスライドにビデオを追加する方法が2つあります：

* ローカルビデオ（マシンに保存されたもの）を追加または埋め込む
* オンラインビデオ（YouTubeなどのウェブソースから）を追加する。

Aspose.Slidesは、プレゼンテーションにビデオ（ビデオオブジェクト）を追加できるように、[IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/)インターフェイス、[IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/)インターフェイス、およびその他の関連タイプを提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオファイルがローカルに保存されている場合、プレゼンテーションにビデオを埋め込むためのビデオフレームを作成できます。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/)オブジェクトを追加し、ビデオファイルのパスを渡してプレゼンテーションにビデオを埋め込みます。
1. ビデオのフレームを作成するために[IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/)オブジェクトを追加します。
1. 修正されたプレゼンテーションを保存します。

このC++コードは、ローカルに保存されたビデオをプレゼンテーションに追加する方法を示しています：

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// ビデオを読み込みます
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// 最初のスライドを取得し、ビデオフレームを追加します
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// プレゼンテーションをディスクに保存します
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```

また、[AddVideoFrame()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/)メソッドにビデオのファイルパスを直接渡してビデオを追加することもできます：

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **ウェブソースからのビデオフレームの作成**

Microsoft [PowerPoint 2013以降](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us)は、プレゼンテーションでYouTubeビデオをサポートしています。使用したいビデオがオンライン（例：YouTubeに）で利用可能な場合、そのウェブリンクを介してプレゼンテーションに追加できます。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成します
1. インデックスを通じてスライドの参照を取得します。
1. [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/)オブジェクトを追加し、ビデオのリンクを渡します。
1. ビデオフレームのサムネイルを設定します。
1. プレゼンテーションを保存します。

このC++コードは、ウェブからビデオをスライドに追加する方法を示しています：

```c++
// ドキュメントディレクトリへのパス。
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセスします
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// ビデオフレームを追加します
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// ビデオの再生モードと音量を設定します
vf->set_PlayMode(VideoPlayModePreset::Auto);

// プレゼンテーションをディスクに保存します
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **スライドからビデオを抽出する**

ビデオをスライドに追加するだけでなく、Aspose.Slidesはプレゼンテーションに埋め込まれたビデオを抽出することもできます。

1. ビデオを含むプレゼンテーションをロードするために[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. すべての[ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/)オブジェクトを反復処理します。
3. [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)オブジェクトをすべて反復処理して[VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/)を見つけます。
4. ビデオをディスクに保存します。

このC++コードは、プレゼンテーションスライドからビデオを抽出する方法を示しています：

```c++
// ドキュメントディレクトリへのパス。
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