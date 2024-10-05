---
title: オーディオフレーム
type: docs
weight: 10
url: /cpp/audio-frame/
keywords: "オーディオを追加, オーディオフレーム, オーディオのプロパティ, オーディオを抽出, C++, CPP, Aspose.Slides for C++"
description: "C++でPowerPointプレゼンテーションにオーディオを追加"
---

## **オーディオフレームの作成**
Aspose.Slides for C++を使用すると、スライドにオーディオファイルを追加できます。オーディオファイルはオーディオフレームとしてスライドに埋め込まれます。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに埋め込むオーディオファイルストリームをロードします。
4. スライドに埋め込まれたオーディオフレーム（オーディオファイルを含む）を追加します。
5. [IAudioFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_audio_frame)オブジェクトで公開されている[PlayMode](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c)と`Volume`を設定します。
6. 修正されたプレゼンテーションを保存します。

このC++コードは、埋め込まれたオーディオフレームをスライドに追加する方法を示しています：

``` cpp
// プレゼンテーションファイルを表すPresentationクラスをインスタンス化
auto pres = System::MakeObject<Presentation>();

// 最初のスライドを取得
auto sld = pres->get_Slides()->idx_get(0);

// wav音声ファイルをストリームに読み込む
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// オーディオフレームを追加
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// オーディオの再生モードと音量を設定
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// PowerPointファイルをディスクに書き込む
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **オーディオフレームのサムネイルの変更**

プレゼンテーションにオーディオファイルを追加すると、オーディオは標準のデフォルト画像を持つフレームとして表示されます（以下のセクションの画像を参照）。オーディオフレームのサムネイルを変更（好みの画像を設定）できます。

このC++コードは、オーディオフレームのサムネイルまたはプレビュー画像を変更する方法を示しています：

```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// 指定した位置とサイズでスライドにオーディオフレームを追加
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// プレゼンテーションリソースに画像を追加
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// オーディオフレームの画像を設定
audioFrame->get_PictureFormat()->get_Picture()->set_Image(audioImage); // <-----
        
// 修正されたプレゼンテーションをディスクに保存
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **オーディオ再生オプションの変更**

Aspose.Slides for C++を使用すると、オーディオの再生やプロパティを制御するオプションを変更できます。たとえば、オーディオの音量を調整したり、ループ再生を設定したり、オーディオアイコンを隠すことができます。

Microsoft PowerPointの**オーディオオプション**パネル：

![example1_image](audio_frame_0.png)

PowerPointオーディオオプションは、Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame)メソッドに対応しています：
- オーディオオプションの**開始**ドロップダウンリストは[AudioFrame::get_PlayMode()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a5379c1a9c1166234d674b32413215a2b)メソッドと一致
- オーディオオプションの**音量**は[AudioFrame::get_Volume()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#af06a3176684b6a13326bc8526747d9f3)メソッドと一致
- オーディオオプションの**スライド間で再生**は[AudioFrame::get_PlayAcrossSlides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a3c6ffc45b319ce127384fc37e188f7b0)メソッドと一致
- オーディオオプションの**停止するまでループ**は[AudioFrame::get_PlayLoopMode()](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a99b5b9cc650e93eba813bd8b2371315b)メソッドと一致
- オーディオオプションの**スライドショー中に隠す**は[AudioFrame::get_HideAtShowing() ](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#abd008322e6a3d7d06bed527e329a9082)メソッドと一致
- オーディオオプションの**再生後に巻き戻す**は[AudioFrame::get_RewindAudio() ](https://reference.aspose.com/slides/cpp/class/aspose.slides.audio_frame#a4900e1df6477db16e8cdd859ad54e637)メソッドと一致

これがオーディオ再生オプションを変更する方法です：

1. [オーディオフレームの作成](#creating-audio-frame)または取得します。
2. 調整したいオーディオフレームのプロパティに新しい値を設定します。
3. 修正されたPowerPointファイルを保存します。

このC++コードは、オーディオのオプションが調整される操作を示しています：

``` cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// 形状を取得
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// 形状をAudioFrame形状にキャスト
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// クリック時に再生するように再生モードを設定
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// 音量を低に設定
audioFrame->set_Volume(AudioVolumeMode::Low);

// オーディオをスライド間で再生するように設定
audioFrame->set_PlayAcrossSlides(true);

// オーディオのループを無効にする
audioFrame->set_PlayLoopMode(false);

// スライドショー中にAudioFrameを隠す
audioFrame->set_HideAtShowing(true);

// 再生後にオーディオを巻き戻す
audioFrame->set_RewindAudio(true);

// PowerPointファイルをディスクに保存
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```

## **オーディオの抽出**
Aspose.Slides for .NETを使用すると、スライドショーの遷移に使用される音声を抽出できます。たとえば、特定のスライドで使用されている音声を抽出できます。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成し、オーディオを含むプレゼンテーションをロードします。
2. インデックスを使用して関連するスライドの参照を取得します。
3. スライドのスライドショー遷移にアクセスします。
4. バイトデータとして音声を抽出します。

このC++コードは、スライドで使用されている音声を抽出する方法を示しています：

``` cpp
String presName = u"AudioSlide.pptx";

// プレゼンテーションファイルを表すPresentationクラスをインスタンス化
auto pres = System::MakeObject<Presentation>(presName);

// 必要なスライドにアクセス
auto slide = pres->get_Slides()->idx_get(0);

// スライドに対するスライドショー遷移効果を取得
auto transition = slide->get_SlideShowTransition();

// バイト配列として音声を抽出
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"長さ: ") + audio->get_Length());
```