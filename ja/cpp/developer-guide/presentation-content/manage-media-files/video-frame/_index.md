---
title: "C++ を使用したプレゼンテーションでのビデオフレームの管理"
linktitle: "ビデオフレーム"
type: docs
weight: 10
url: /ja/cpp/video-frame/
keywords:
- "ビデオを追加"
- "ビデオを作成"
- "ビデオを埋め込む"
- "ビデオを抽出"
- "ビデオを取得"
- "ビデオフレーム"
- "Web ソース"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides for C++ を使用して、PowerPoint と OpenDocument スライドでビデオフレームをプログラム的に追加および抽出する方法を学びます。高速ハウツーガイド。"
---
## **導入**

ビデオは、アイデアを説明し、聴衆の関心を引くのに役立ちます。Aspose.Slides for C++ を使用すると、スライドにビデオフレームを追加し、再生設定を調整し、キャプションを管理し、埋め込みビデオデータを抽出できます。

PowerPoint はローカルビデオと、YouTube ビデオなどのオンラインビデオへのリンクをサポートします。

ビデオデータおよびビデオフレームを表すために、Aspose.Slides は [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) インターフェイス、[IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) インターフェイス、およびその他の関連型を提供します。

## **埋め込みビデオフレームの作成**

スライドに追加したいビデオファイルがローカルに保存されている場合、プレゼンテーションにビデオを埋め込むビデオフレームを作成できます。

この例は、既存のプレゼンテーションの最初のスライドにローカルビデオを埋め込み、結果を保存します。フレームの座標とサイズはポイント単位です。ストリームは、[LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/cpp/aspose.slides/loadingstreambehavior/) がプレゼンテーションで使用中にロックされたままになるため、保存が完了するまで開いたままです。

```cpp
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <Export/SaveFormat.h>
#include <LoadingStreamBehavior.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto videoStream = File::OpenRead(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::KeepLocked);
slide->get_Shapes()->AddVideoFrame(10, 10, 150, 250, video);

presentation->Save(u"embedded_video.pptx", SaveFormat::Pptx);

presentation->Dispose();
videoStream->Dispose();
```

ローカルビデオのパスを直接 [AddVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/) に渡すこともできます。この例は、新しいプレゼンテーションの最初のスライドにビデオを埋め込みます。ビデオはプレゼンテーションが保存されるまでアクセス可能な状態である必要があります。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

slide->get_Shapes()->AddVideoFrame(50, 150, 300, 150, u"video.avi");

presentation->Save(u"video_from_path.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Web ソースからのビデオでビデオフレームを作成**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) はプレゼンテーションでオンラインビデオをサポートしています。YouTube ビデオなどのオンラインビデオへのリンクを持つビデオフレームを作成できます。

この例は、最初のスライドに YouTube ビデオのリンクとサムネイルを追加します。別のビデオを使用する場合はビデオ識別子を置き換えてください。[set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_playmode/) メソッドは自動再生を要求します。サムネイルのダウンロードとビデオの再生にはインターネット接続が必要です。プレゼンテーションビューアもオンラインビデオの再生をサポートしている必要があります。

```cpp
#include <net/web_client.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <DOM/VideoPlayModePreset.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);


auto webClient = MakeObject<System::Net::WebClient>();

String videoId = u"aqz-KE-bpKQ";
auto videoUrl = String::Format(u"https://www.youtube.com/embed/{0}", videoId);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

auto thumbnailUrl = String::Format(u"https://img.youtube.com/vi/{0}/hqdefault.jpg", videoId);
auto thumbnailData = webClient->DownloadData(thumbnailUrl);
auto thumbnail = presentation->get_Images()->AddImage(thumbnailData);
videoFrame->get_PictureFormat()->get_Picture()->set_Image(thumbnail);

presentation->Save(u"online_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **全画面モードでビデオを再生**

トレーニング用プレゼンテーションでは、ソフトウェアデモを全画面モードで再生することで、聴衆が詳細を見ることができます。[set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) は `true` を受け入れ、再生中にこの動作を有効にします。

この例はプレゼンテーションを開き、最初のスライド上の最初の [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) を見つけ、全画面再生を有効にします。入力プレゼンテーションには、最初のスライドに既存のビデオフレームが少なくとも1つ含まれている必要があります。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"training.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        videoFrame->set_FullScreenMode(true);
        break;
    }
}

presentation->Save(u"full_screen_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

全画面再生はビデオの表示方法を制御します。別個に、[set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) は自動再生かクリック時再生かを制御し、[set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) はループするかどうかを制御します。開始動作を選択するには、[VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) に再生モードを設定します。例は既存の開始およびループ設定を保持します。

## **再生後にビデオを巻き戻す**

トレーニング用プレゼンテーションでは、デモビデオを最初に戻すことで、プレゼンターが再度再生できるようにします。[set_RewindVideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_rewindvideo/) に `true` を指定すると、再生が終了した後にビデオを最初に戻します。

この例はプレゼンテーションを開き、最初のスライド上の最初の [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) を見つけ、巻き戻しを有効にします。ループを無効にして再生が終了できるようにし、クリック時開始に設定します。入力プレゼンテーションには、最初のスライドに既存のビデオフレームが少なくとも1つ含まれている必要があります。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <DOM/VideoPlayModePreset.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"training.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        videoFrame->set_RewindVideo(true);
        videoFrame->set_PlayLoopMode(false);
        videoFrame->set_PlayMode(VideoPlayModePreset::OnClick);
        break;
    }
}

presentation->Save(u"rewind_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

巻き戻しはビデオを最初に戻しますが、再度開始はしません。[set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) を有効にすると再生が自動的に繰り返されます。ビデオが終了し、再生待機状態を保ちたい場合はループを無効にしてください。[set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) は自動開始かクリック開始かを個別に制御します。この例では [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) を使用してプレゼンターが開始タイミングを制御できるようにしています。ループ設定の後に再生モードを設定してください。[set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) とは独立して機能します。

## **ビデオフレームのトリミング**

[IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromstart/) と [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromend/) を使用して、再生時にビデオの開始部または終了部の一部をスキップできます。両方の値はミリ秒単位です。トリミングは埋め込みビデオデータを変更せずに再生設定を変更します。

**トリム設定**

この例はローカルビデオを埋め込み、再生時に最初の 2.5 秒と最後の 1 秒をスキップします。再生可能なセグメントが残るように、3.5 秒より長いビデオを使用してください。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 640, 360, video);
videoFrame->set_TrimFromStart(2500.0f);
videoFrame->set_TrimFromEnd(1000.0f);

presentation->Save(u"video_with_trim.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**トリム設定の取得**

この例は最初のスライド上の最初のビデオフレームのトリム値をミリ秒で出力します。プレゼンテーションには少なくとも1枚のスライドが必要です。そのスライドにビデオフレームがない場合は何も出力されません。前の例は 2500 と 1000 の値を生成します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"video_with_trim.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        Console::WriteLine(String::Format(u"Trim from start: {0} ms", videoFrame->get_TrimFromStart()));
        Console::WriteLine(String::Format(u"Trim from end: {0} ms", videoFrame->get_TrimFromEnd()));
        break;
    }
}

presentation->Dispose();
```

## **ビデオキャプションの管理**

Aspose.Slides は PowerPoint プレゼンテーション内のビデオフレームに対してクローズドキャプションを管理できるようにします。キャプションは WebVTT 形式で保存され、[IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/) メソッドで取得できます。

**ビデオフレームにキャプションを追加**

この例はローカルビデオを埋め込み、英語というラベルの WebVTT キャプショントラックを追加します。キャプションのタイムスタンプはビデオに合わせる必要があります。保存されたプレゼンテーションにはビデオとキャプションの両方が含まれます。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <DOM/ICaptionsCollection.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) インターフェイスは、ストリームからキャプションを追加できるオーバーロードも提供します。

**ビデオフレームからキャプションを抽出**

この例は最初のスライド上のビデオフレームからすべてのキャプショントラックを個別の WebVTT ファイルとして保存します。連番が出力ファイルを区別します。コンソールは抽出されたトラック数を報告します。プレゼンテーションには少なくとも1枚のスライドが必要です。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <system/io/file.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/ICaptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

auto trackCount = 0;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        for (auto&& captionTrack : IterateOver(videoFrame->get_CaptionTracks()))
        {
            trackCount++;
            auto outputPath = String::Format(u"captions_{0}.vtt", trackCount);
            File::WriteAllBytes(outputPath, captionTrack->get_BinaryData());
        }
    }
}

Console::WriteLine(String::Format(u"Caption tracks extracted: {0}", trackCount));

presentation->Dispose();
```

各 [ICaptions](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/) オブジェクトはキャプション識別子、ラベル、バイナリデータ、および UTF-8 文字列としてのキャプションテキストを公開します。

**ビデオフレームからキャプションを削除**

この例は最初のスライド上の最初のシェイプ位置にあるビデオフレームからすべてのキャプションを削除し、結果を保存します。スライドとシェイプが存在し、シェイプがビデオフレームであることを前提としています。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <DOM/ICaptionsCollection.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

1 つのキャプショントラックだけを削除したい場合は、[Clear](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/clear/) の代わりに [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/remove/) または [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/removeat/) メソッドを使用してください。

## **スライドからビデオを抽出**

ビデオをスライドに追加するだけでなく、Aspose.Slides はプレゼンテーションに埋め込まれたビデオを抽出することも可能です。

この例はすべてのスライドから埋め込みビデオを個別の番号付きバイナリファイルに抽出します。リンクされたビデオは埋め込みデータがないためスキップされます。コンソールは各ビデオの MIME タイプと総数を出力します。出力は汎用的な `.bin` 拡張子を使用します。必要に応じてレポートされたメディアタイプに合わせて変更してください。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IVideo.h>
#include <system/io/file.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation_with_videos.pptx");

auto videoCount = 0;
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IVideoFrame>(shape))
        {
            auto videoFrame = ExplicitCast<IVideoFrame>(shape);
            auto video = videoFrame->get_EmbeddedVideo();
            if (video == nullptr)
            {
                Console::WriteLine(u"Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            auto outputPath = String::Format(u"extracted_video_{0}.bin", videoCount);
            File::WriteAllBytes(outputPath, video->get_BinaryData());
            Console::WriteLine(String::Format(u"Video {0}: {1}", videoCount, video->get_ContentType()));
        }
    }
}

Console::WriteLine(String::Format(u"Embedded videos extracted: {0}", videoCount));

presentation->Dispose();
```

## **よくある質問**

**ビデオフレームの再生パラメーターで変更できるものは何ですか？**

[playback mode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/)（自動またはクリック時）と [looping](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) を制御できます。これらのオプションは [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/) オブジェクトのメソッドで利用可能です。

**ビデオを追加すると PPTX ファイルのサイズが増えますか？**

はい。ローカルビデオを埋め込むと、バイナリデータがドキュメントに含まれるため、プレゼンテーションのサイズはビデオファイルのサイズに比例して大きくなります。オンラインビデオへのリンクとサムネイルだけを追加する場合は、ビデオデータは保存されずリンクとプレビュー画像だけが保存されるため、サイズ増加は通常小さくなります。

**既存のビデオフレームのビデオを、位置やサイズを変更せずに置き換えることはできますか？**

はい。フレームのジオメトリを保持したまま、フレーム内の [video content](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) を入れ替えることができます。これは既存のレイアウトでメディアを更新する一般的なシナリオです。

**埋め込みビデオのコンテンツタイプ (MIME) を取得できますか？**

はい。埋め込みビデオには [content type](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/) があり、取得してディスクに保存する際などに利用できます。