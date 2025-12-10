---
title: C++ を使用したプレゼンテーションでのビデオフレームの管理
linktitle: ビデオフレーム
type: docs
weight: 10
url: /ja/cpp/video-frame/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument のスライドにビデオフレームをプログラムで追加および抽出する方法を学びます。高速ハウツーガイド。"
---

プレゼンテーションに適切に配置されたビデオは、メッセージをより説得力のあるものにし、聴衆とのエンゲージメントレベルを高めることができます。

PowerPoint では、プレゼンテーションのスライドにビデオを追加する方法が 2 つあります:

* ローカルビデオを追加または埋め込む（マシンに保存されているもの）
* オンラインビデオを追加する（YouTube などの Web ソースから）

ビデオ（ビデオオブジェクト）をプレゼンテーションに追加できるように、Aspose.Slides は[IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/)インターフェイス、[IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/)インターフェイス、その他の関連型を提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオ ファイルがローカルに保存されている場合、プレゼンテーションにビデオを埋め込むビデオフレームを作成できます。

1. [Presentation ](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. ビデオ ファイルのパスを渡して[IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/)オブジェクトを追加し、ビデオをプレゼンテーションに埋め込みます。  
4. ビデオ用のフレームを作成するために[IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/)オブジェクトを追加します。  
5. 修正したプレゼンテーションを保存します。  

この C++ コードは、ローカルに保存されたビデオをプレゼンテーションに追加する方法を示しています:
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


あるいは、[AddVideoFrame()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/) メソッドにファイル パスを直接渡してビデオを追加することもできます:
``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```


## **Web ソースからのビデオでフレームを作成する**

Microsoft の[PowerPoint 2013 以降](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us)は、プレゼンテーションで YouTube ビデオをサポートしています。使用したいビデオがオンライン（例: YouTube）にある場合、その Web リンクを使用してプレゼンテーションに追加できます。

1. [Presentation ](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. ビデオへのリンクを渡して[IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/)オブジェクトを追加します。  
4. ビデオフレームのサムネイルを設定します。  
5. プレゼンテーションを保存します。  

この C++ コードは、Web からビデオを取得して PowerPoint のスライドに追加する方法を示しています:
```c++
// ドキュメントディレクトリへのパス。
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセス
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// ビデオフレームを追加 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// ビデオの再生モードと音量を設定
vf->set_PlayMode(VideoPlayModePreset::Auto);

//プレゼンテーションをディスクに保存
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **スライドからビデオを抽出する**

ビデオをスライドに追加するだけでなく、Aspose.Slides はプレゼンテーションに埋め込まれたビデオを抽出することも可能です。

1. ビデオを含むプレゼンテーションを読み込むために、[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成します。  
2. すべての[ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/)オブジェクトを列挙します。  
3. すべての[IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)オブジェクトを列挙し、[VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/) を見つけます。  
4. ビデオをディスクに保存します。  

この C++ コードは、プレゼンテーション スライドからビデオを抽出する方法を示しています:
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


## **FAQ**

**VideoFrame の再生パラメータで変更できる項目はどれですか？**

[playback mode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/)（自動またはクリック時）と[looping](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) を制御できます。これらのオプションは[VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/)オブジェクトのプロパティで利用可能です。

**ビデオを追加すると PPTX のファイルサイズは増加しますか？**

はい。ローカルビデオを埋め込む場合、バイナリ データが文書に含まれるため、プレゼンテーションのサイズはファイル サイズに比例して増加します。オンラインビデオを追加する場合はリンクとサムネイルが埋め込まれるだけなので、サイズ増加は小さくなります。

**既存の VideoFrame の位置やサイズを変更せずにビデオを置き換えることはできますか？**

はい。フレーム内の[video content](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) を入れ替えることで、シェイプのジオメトリを保持したままビデオを更新できます。これは既存レイアウトのメディアを更新する一般的なシナリオです。

**埋め込みビデオのコンテンツタイプ（MIME）を取得できますか？**

はい。埋め込みビデオには[content type](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/) があり、取得してディスクに保存する際などに使用できます。