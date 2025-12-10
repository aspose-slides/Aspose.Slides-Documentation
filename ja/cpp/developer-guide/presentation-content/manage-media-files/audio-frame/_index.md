---
title: C++ を使用したプレゼンテーションでのオーディオ管理
linktitle: オーディオ フレーム
type: docs
weight: 10
url: /ja/cpp/audio-frame/
keywords:
- オーディオ
- オーディオ フレーム
- サムネイル
- オーディオの追加
- オーディオ プロパティ
- オーディオ オプション
- オーディオの抽出
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ のオーディオ フレームを作成および制御します—コード例では、埋め込み、トリム、ループ、PPT、PPTX、ODP プレゼンテーション全体での再生設定が示されています。"
---

## **オーディオ フレームの作成**

Aspose.Slides for C++ を使用すると、スライドにオーディオ ファイルを追加できます。オーディオ ファイルはオーディオ フレームとしてスライドに埋め込まれます。 

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに埋め込むオーディオ ファイルのストリームをロードします。
4. 埋め込みオーディオ フレーム（オーディオ ファイルを含む）をスライドに追加します。
5. [PlayMode](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) と、[IAudioFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_audio_frame) オブジェクトが公開する `Volume` を設定します。
6. 変更されたプレゼンテーションを保存します。

この C++ コードは、スライドに埋め込みオーディオ フレームを追加する方法を示しています。
``` cpp
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
auto pres = System::MakeObject<Presentation>();

// 最初のスライドを取得します
auto sld = pres->get_Slides()->idx_get(0);

// wav 音声ファイルをストリームに読み込みます
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// オーディオ フレームを追加します
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// オーディオの再生モードと音量を設定します
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// PowerPoint ファイルをディスクに保存します
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```


## **オーディオ フレームのサムネイルの変更**

プレゼンテーションにオーディオ ファイルを追加すると、オーディオは標準のデフォルト画像が設定されたフレームとして表示されます（以下のセクションの画像を参照）。オーディオ フレームのサムネイルを変更（好みの画像を設定）できます。

この C++ コードは、オーディオ フレームのサムネイルまたはプレビュー画像を変更する方法を示しています。
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
        
//変更されたプレゼンテーションをディスクに保存します
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


## **オーディオ 再生オプションの変更**

Aspose.Slides for C++ を使用すると、オーディオの再生やプロパティを制御するオプションを変更できます。たとえば、オーディオの音量を調整したり、ループ再生に設定したり、オーディオ アイコンを非表示にしたりできます。

Microsoft PowerPoint の **Audio Options** ペイン:
![example1_image](audio_frame_0.png)

PowerPoint の **Audio Options** は、Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/) メソッドに対応しています:
- **Start** ドロップダウン リストは、[AudioFrame::set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_playmode/) メソッドに対応しています 
- **Volume** は、[AudioFrame::set_Volume](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_volume/) メソッドに対応しています 
- **Play Across Slides** は、[AudioFrame::set_PlayAcrossSlides](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_playacrossslides/) メソッドに対応しています 
- **Loop until Stopped** は、[AudioFrame::set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_playloopmode/) メソッドに対応しています 
- **Hide During Show** は、[AudioFrame::set_HideAtShowing](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_hideatshowing/) メソッドに対応しています 
- **Rewind after Playing** は、[AudioFrame::set_RewindAudio](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_rewindaudio/) メソッドに対応しています 

PowerPoint の **Editing** オプションは、Aspose.Slides の [AudioFrame](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/) プロパティに対応しています:
- **Fade In** は、[AudioFrame.set_FadeInDuration](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_fadeinduration/) メソッドに対応しています
- **Fade Out** は、[AudioFrame.set_FadeOutDuration](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_fadeoutduration/) メソッドに対応しています
- **Trim Audio Start Time** は、[AudioFrame.set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_trimfromstart/) メソッドに対応しています
- **Trim Audio End Time** の値は、[AudioFrame.set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_trimfromend/) メソッドの値をオーディオの長さから差し引いたものに等しくなります

PowerPoint のオーディオ コントロール パネルにある **Volume controll** は、[AudioFrame.set_VolumeValue](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_volumevalue/) メソッドに対応しています。音量をパーセンテージで変更できます。

オーディオ 再生オプションを変更する手順は次のとおりです:
1. [作成](#creating-audio-frame)または Audio Frame を取得します。
2. 調整したい Audio Frame のプロパティに新しい値を設定します。
3. 変更された PowerPoint ファイルを保存します。

この C++ コードは、オーディオのオプションを調整する操作を示しています。
``` cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// シェイプを取得します
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// シェイプを AudioFrame シェイプにキャストします
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// クリックで再生するように再生モードを設定します
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// 音量を低に設定します
audioFrame->set_Volume(AudioVolumeMode::Low);

// オーディオをスライド全体で再生するように設定します
audioFrame->set_PlayAcrossSlides(true);

// オーディオのループを無効にします
audioFrame->set_PlayLoopMode(false);

// スライドショー中に AudioFrame を非表示にします
audioFrame->set_HideAtShowing(true);

// 再生後にオーディオを先頭に巻き戻します
audioFrame->set_RewindAudio(true);

// PowerPoint ファイルをディスクに保存します
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```


この C++ の例は、埋め込みオーディオを持つ新しいオーディオ フレームを追加し、トリムし、フェード時間を設定する方法を示しています。
```cpp
auto pres = MakeObject<Presentation>();
auto slide = pres->get_Slide(0);

auto audioData = File::ReadAllBytes(u"sampleaudio.mp3");
auto audio = pres->get_Audios()->AddAudio(audioData);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audio);

// Sets the trimming start offset to 1.5 seconds
audioFrame->set_TrimFromStart(1500);
// Sets the trimming end offset to 2 seconds
audioFrame->set_TrimFromEnd(2000);

// Sets the fade-in duration to 200 ms
audioFrame->set_FadeInDuration(200);
// Sets the fade-out duration to 500 ms
audioFrame->set_FadeOutDuration(500);

pres->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```


次のコード サンプルは、埋め込みオーディオを持つオーディオ フレームを取得し、音量を 85% に設定する方法を示しています。
```cpp
auto pres = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
    
// オーディオフレームのシェイプを取得します
auto audioFrame = ExplicitCast<IAudioFrame>(pres->get_Slide(0)->get_Shape(0));

// オーディオの音量を 85% に設定します
audioFrame->set_VolumeValue(85);

pres->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```


## **オーディオの抽出**
Aspose.Slides を使用すると、スライド ショーの遷移で使用されるサウンドを抽出できます。たとえば、特定のスライドで使用されるサウンドを抽出できます。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成し、オーディオを含むプレゼンテーションをロードします。
2. インデックスを使用して対象スライドの参照を取得します。
3. スライドのスライドショー遷移にアクセスします。
4. サウンドをバイト データとして抽出します。

この C++ コードは、スライドで使用されるオーディオを抽出する方法を示しています。
``` cpp
String presName = u"AudioSlide.pptx";

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
auto pres = System::MakeObject<Presentation>(presName);

// 対象のスライドにアクセスします
auto slide = pres->get_Slides()->idx_get(0);

// スライドのスライドショー遷移効果を取得します
auto transition = slide->get_SlideShowTransition();

// サウンドをバイト配列として抽出します
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```


## **FAQ**

**同じオーディオ アセットを複数のスライドで再利用して、ファイル サイズを増やさないようにできますか？**

はい。オーディオをプレゼンテーションの共有 [audio collection](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_audios/) に一度追加し、既存のアセットを参照する追加のオーディオ フレームを作成します。これによりメディア データの重複を防ぎ、プレゼンテーションのサイズを抑制できます。

**既存のオーディオ フレームのサウンドを、シェイプを再作成せずに置き換えることはできますか？**

はい。リンクされたサウンドの場合は、[link path](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_linkpathlong/) を新しいファイルを指すように更新します。埋め込みサウンドの場合は、プレゼンテーションの [audio collection](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_audios/) から別のものに [embedded audio](https://reference.aspose.com/slides/cpp/aspose.slides/audioframe/set_embeddedaudio/) オブジェクトを入れ替えます。フレームの書式設定やほとんどの再生設定はそのまま保持されます。

**トリミングは、プレゼンテーションに保存されている元のオーディオ データを変更しますか？**

いいえ。トリミングは再生範囲のみを調整します。元のオーディオ バイトはそのまま残り、埋め込みオーディオまたはプレゼンテーションのオーディオ コレクションからアクセス可能です。