---
title: C++ を使用したプレゼンテーションのオーディオ管理
linktitle: オーディオ フレーム
type: docs
weight: 10
url: /ja/cpp/audio-frame/
keywords:
- オーディオ
- オーディオ フレーム
- サムネイル
- オーディオ を追加
- オーディオ プロパティ
- オーディオ オプション
- オーディオ の抽出
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ でオーディオ フレームを作成および制御します—埋め込み、トリミング、ループ、再生設定を PPT、PPTX、ODP プレゼンテーション全体で行うコード例です。"
---
## **オーディオフレームの作成**

Aspose.Slides for C++ を使用すると、スライドにオーディオ ファイルを追加できます。オーディオ ファイルはオーディオ フレームとしてスライドに埋め込まれます。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドに埋め込むオーディオ ファイル ストリームをロードします。  
4. 埋め込まれたオーディオ フレーム（オーディオ ファイルを含む）をスライドに追加します。  
5. IAudioFrame オブジェクトが提供する [PlayMode](https://reference.aspose.com/slides/ja/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) と `Volume` を設定します。  
6. 変更されたプレゼンテーションを保存します。

この C++ コードは、スライドに埋め込みオーディオ フレームを追加する方法を示します:

``` cpp
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
auto pres = System::MakeObject<Presentation>();

// 最初のスライドを取得します
auto sld = pres->get_Slides()->idx_get(0);

// wav サウンド ファイルをストリームにロードします
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// オーディオ フレームを追加します
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// オーディオの再生モードと音量を設定します
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// PowerPoint ファイルをディスクに保存します
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **オーディオ フレームのサムネイルを変更する**

プレゼンテーションにオーディオ ファイルを追加すると、標準のデフォルト画像が付いたフレームとして表示されます（下の画像参照）。オーディオ フレームのサムネイル（任意の画像）に変更できます。

この C++ コードは、オーディオ フレームのサムネイルまたはプレビュー画像を変更する方法を示します:

```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// 指定した位置とサイズでスライドにオーディオ フレームを追加します。
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// プレゼンテーションのリソースに画像を追加します。
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// オーディオ フレームの画像を設定します。
audioFrame->get_PictureFormat()->get_Picture()->set_Image(audioImage); // <-----
        
// 変更されたプレゼンテーションをディスクに保存します
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **オーディオ再生オプションの変更**

Aspose.Slides for C++ では、オーディオの再生やプロパティを制御するオプションを変更できます。たとえば、音量を調整したり、ループ再生に設定したり、オーディオ アイコンを非表示にしたりできます。

Microsoft PowerPoint の **Audio Options** ペイン:

![example1_image](audio_frame_0.png)

PowerPoint の **Audio Options** が Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/audioframe/) メソッドに対応しています:

- **Start** のドロップダウン リストは [AudioFrame::set_PlayMode](https://reference.aspose.com/slides/ja/cpp/aspose.slides/audioframe/set_playmode/) メソッドに対応しています  
- **Volume** は [AudioFrame::set_Volume](https://reference.aspose.com/slides/ja/cpp/aspose.slides/audioframe/set_volume/) メソッドに対応しています  
- **Play Across Slides** は [AudioFrame::set_PlayAcrossSlides](https://reference.aspose.com/slides/ja/cpp/aspose.slides/audioframe/set_playacrossslides/) メソッドに対応しています  
- **Loop until Stopped** は [AudioFrame::set_PlayLoopMode](https://reference.aspose.com/slides/ja/cpp/aspose.slides/audioframe/set_playloopmode/) メソッドに対応しています  
- **Hide During Show** は [AudioFrame::set_HideAtShowing](https://reference.aspose.com/slides/ja/cpp/aspose.slides/audioframe/set_hideatshowing/) メソッドに対応しています  
- **Rewind after Playing** は [AudioFrame::set_RewindAudio](https://reference.aspose.com/slides/ja/cpp/aspose.slides/audioframe/set_rewindaudio/) メソッドに対応しています  

PowerPoint の **Editing** オプションが Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/audioframe/) プロパティに対応しています:

- **Fade In** は [AudioFrame.set_FadeInDuration](https://reference.aspose.com/slides/ja/cpp/aspose.slides/audioframe/set_fadeinduration/) メソッドに対応しています  
- **Fade Out** は [AudioFrame.set_FadeOutDuration](https://reference.aspose.com/slides/ja/cpp/aspose.slides/audioframe/set_fadeoutduration/) メソッドに対応しています  
- **Trim Audio Start Time** は [AudioFrame.set_TrimFromStart](https://reference.aspose.com/slides/ja/cpp/aspose.slides/audioframe/set_trimfromstart/) メソッドに対応しています  
- **Trim Audio End Time** の値は、オーディオの全長から [AudioFrame.set_TrimFromEnd](https://reference.aspose.com/slides/ja/cpp/aspose.slides/audioframe/set_trimfromend/) メソッドの値を引いたものに相当します  

オーディオ コントロール パネル上の PowerPoint の **Volume controll** は [AudioFrame.set_VolumeValue](https://reference.aspose.com/slides/ja/cpp/aspose.slides/audioframe/set_volumevalue/) メソッドに対応しており、音量をパーセンテージで変更できます。

オーディオ 再生オプションを変更する手順:

1. [Audio Frame を作成](#creating-audio-frame)するか取得します。  
2. 調整したいオーディオ フレーム プロパティに新しい値を設定します。  
3. 変更された PowerPoint ファイルを保存します。

この C++ コードは、オーディオのオプションを調整する操作を示します:

``` cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// シェイプを取得
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// シェイプを AudioFrame にキャスト
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// 再生モードをクリックで再生に設定
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// 音量を Low に設定
audioFrame->set_Volume(AudioVolumeMode::Low);

// オーディオをスライド間で再生するように設定
audioFrame->set_PlayAcrossSlides(true);

// オーディオのループを無効に設定
audioFrame->set_PlayLoopMode(false);

// スライドショー中に AudioFrame を非表示に設定
audioFrame->set_HideAtShowing(true);

// 再生後にオーディオを先頭に巻き戻すように設定
audioFrame->set_RewindAudio(true);

// PowerPoint ファイルをディスクに保存
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```

この C++ 例は、埋め込みオーディオを持つ新しいオーディオ フレームを追加し、トリミングとフェード時間の設定を行う方法を示します:

```cpp
auto pres = MakeObject<Presentation>();
auto slide = pres->get_Slide(0);

auto audioData = File::ReadAllBytes(u"sampleaudio.mp3");
auto audio = pres->get_Audios()->AddAudio(audioData);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audio);

// トリミング開始オフセットを1.5秒に設定します
audioFrame->set_TrimFromStart(1500);
// トリミング終了オフセットを2秒に設定します
audioFrame->set_TrimFromEnd(2000);

// フェードイン時間を200ミリ秒に設定します
audioFrame->set_FadeInDuration(200);
// フェードアウト時間を500ミリ秒に設定します
audioFrame->set_FadeOutDuration(500);

pres->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

以下のコード サンプルは、埋め込みオーディオを持つオーディオ フレームを取得し、音量を 85% に設定する方法を示します:

```cpp
auto pres = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
    
// オーディオ フレーム シェイプを取得します
auto audioFrame = ExplicitCast<IAudioFrame>(pres->get_Slide(0)->get_Shape(0));

// オーディオ ボリュームを85%に設定します
audioFrame->set_VolumeValue(85);

pres->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

## **オーディオキャプションの管理**

Aspose.Slides では、[get_CaptionTracks](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iaudioframe/get_captiontracks/) メソッドを使用してオーディオ フレームにクローズド キャプションを追加できます。このメソッドは [ICaptionsCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icaptionscollection/) を返し、WebVTT キャプション トラックの追加、既存トラックの列挙、必要に応じた削除が可能です。

**オーディオキャプションの追加**

[IAudioFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iaudioframe/) の [get_CaptionTracks](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iaudioframe/get_captiontracks/) メソッドを使用して、1 つ以上のキャプション トラックをオーディオ フレームに添付します。以下の例では、スライドにオーディオ ファイルを追加し、`.vtt` ファイルから新しいキャプション トラックをロードします。

```cpp
auto presentation = MakeObject<Presentation>();

auto audioData = File::ReadAllBytes(u"audio.mp3");
auto audio = presentation->get_Audios()->AddAudio(audioData);

auto slide = presentation->get_Slide(0);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(10, 10, 50, 50, audio);

// Add a new caption track from a WebVTT file.
audioFrame->get_CaptionTracks()->Add(u"New track", u"track.vtt");

presentation->Save(u"audio_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**オーディオキャプションの抽出**

オーディオ フレームに関連付けられたキャプション トラックを列挙し、`.vtt` ファイルとして保存できます。各キャプション トラックはバイナリ データと固有の識別子を公開しており、キャプションのエクスポート時に使用できます。

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IAudioFrame>(shape))
    {
        auto audioFrame = ExplicitCast<IAudioFrame>(shape);
        for (auto&& captionTrack : audioFrame->get_CaptionTracks())
        {
            // 各キャプショントラックを .vtt ファイルとして保存します。
            auto fileName = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(fileName, captionTrack->get_BinaryData());
        }
    }
}
presentation->Dispose();
```

**オーディオキャプションの削除**

キャプションを削除するには、[ICaptionsCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icaptionscollection/) が提供するメソッド（[Clear](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icaptionscollection/clear/)、[Remove](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icaptionscollection/remove/)、[RemoveAt](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icaptionscollection/removeat/) など）を使用します。以下の例は、オーディオ フレームからすべてのキャプション トラックを削除します。

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto audioFrame = ExplicitCast<IAudioFrame>(slide->get_Shape(0));

// オーディオ フレームからすべてのキャプショントラックを削除します。
audioFrame->get_CaptionTracks()->Clear();

presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **オーディオの抽出**

Aspose.Slides では、スライドショーの切り替え時に使用されるサウンドを抽出できます。たとえば、特定のスライドで使用されているサウンドを抽出できます。

1. オーディオを含むプレゼンテーションをロードするために、[Presentation](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。  
2. インデックスを使用して対象スライドの参照を取得します。  
3. スライドのスライドショー切り替えを取得します。  
4. サウンドをバイト データとして抽出します。

この C++ コードは、スライドで使用されているオーディオを抽出する方法を示します:

``` cpp
String presName = u"AudioSlide.pptx";

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
auto pres = System::MakeObject<Presentation>(presName);

// 目的のスライドにアクセスします
auto slide = pres->get_Slides()->idx_get(0);

// スライドのスライドショー遷移効果を取得します
auto transition = slide->get_SlideShowTransition();

// サウンドをバイト配列として抽出します
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```

## **よくある質問**

**同じオーディオ資産を複数のスライドで再利用して、ファイル サイズが肥大化しないようにできますか？**

はい。プレゼンテーションの共有 [audio collection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_audios/) にオーディオを一度追加し、既存資産を参照する追加のオーディオ フレームを作成します。これによりメディア データの重複が回避され、プレゼンテーションのサイズが抑えられます。

**既存のオーディオ フレームのサウンドを形状を作り直さずに差し替えることはできますか？**

はい。リンクされたサウンドの場合は、[link path](https://reference.aspose.com/slides/ja/cpp/aspose.slides/audioframe/set_linkpathlong/) を新しいファイルに更新します。埋め込みサウンドの場合は、プレゼンテーションの [audio collection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_audios/) から別の埋め込みオーディオ オブジェクトに差し替えます。フレームの書式設定とほとんどの再生設定はそのまま保持されます。

**トリミングはプレゼンテーションに保存されている基礎オーディオ データを変更しますか？**

いいえ。トリミングは再生範囲のみを調整します。元のオーディオ バイトは変更されず、埋め込みオーディオまたはプレゼンテーションのオーディオ コレクションを通じて引き続きアクセス可能です。