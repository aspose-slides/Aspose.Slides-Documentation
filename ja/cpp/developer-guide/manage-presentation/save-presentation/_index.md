---
title: C++ でプレゼンテーションを保存
linktitle: プレゼンテーションを保存
type: docs
weight: 80
url: /ja/cpp/save-presentation/
keywords:
- PowerPoint を保存
- OpenDocument を保存
- プレゼンテーションを保存
- スライドを保存
- PPT を保存
- PPTX を保存
- ODP を保存
- ファイルへのプレゼンテーション
- ストリームへのプレゼンテーション
- 事前定義されたビュータイプ
- Strict Office Open XML 形式
- Zip64 モード
- サムネイルの更新
- 保存の進捗
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して C++ でプレゼンテーションを保存する方法を紹介します。レイアウト、フォント、エフェクトを保持したまま PowerPoint や OpenDocument にエクスポートできます。"
---

## **概要**

[Open Presentations in C++](/slides/ja/cpp/open-presentation/) は、[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスを使用してプレゼンテーションを開く方法を説明しています。この記事では、プレゼンテーションの作成と保存方法について説明します。[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスはプレゼンテーションの内容を保持します。ゼロからプレゼンテーションを作成する場合でも、既存のものを変更する場合でも、完了したら保存したくなります。Aspose.Slides for C++ を使用すると、**ファイル** または **ストリーム** に保存できます。本記事では、プレゼンテーションを保存するさまざまな方法を説明します。

## **ファイルにプレゼンテーションを保存**

[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスの`Save`メソッドを呼び出してプレゼンテーションをファイルに保存します。メソッドにファイル名と保存形式を渡します。以下の例は、Aspose.Slides を使用してプレゼンテーションを保存する方法を示しています。
```cpp
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>();

// ここで何らかの処理を行います...

// プレゼンテーションをファイルに保存します。
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```


## **ストリームへのプレゼンテーション保存**

[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスの`Save`メソッドに出力ストリームを渡すことで、プレゼンテーションをストリームに保存できます。プレゼンテーションはさまざまなストリームタイプに書き込むことができます。以下の例では、新しいプレゼンテーションを作成し、ファイルストリームに保存します。
```cpp
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// ストリームにプレゼンテーションを保存します。
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```


## **事前定義されたビュータイプでプレゼンテーションを保存**

Aspose.Slides を使用すると、生成されたプレゼンテーションが開かれたときに PowerPoint が使用する初期ビューを [ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/) クラスで設定できます。[ViewType](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/) 列挙体の値を使用して、[set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/set_lastview/) メソッドを呼び出します。
```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Strict Office Open XML 形式でプレゼンテーションを保存**

Aspose.Slides を使用すると、プレゼンテーションを Strict Office Open XML 形式で保存できます。保存時に [PptxOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pptxoptions/) クラスを使用し、その conformance プロパティを設定します。`Conformance.Iso29500_2008_Strict` を設定すると、出力ファイルは Strict Office Open XML 形式で保存されます。

以下の例は、プレゼンテーションを作成し、Strict Office Open XML 形式で保存するものです。
```cpp
auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>();

// Strict Office Open XML 形式でプレゼンテーションを保存します。
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```


## **Zip64 モードで Office Open XML 形式のプレゼンテーションを保存**

Office Open XML ファイルは ZIP アーカイブであり、任意のファイルの非圧縮サイズ、圧縮サイズ、アーカイブ全体のサイズに 4 GB (2^32 バイト) の制限を課し、またアーカイブ内のファイル数を 65,535 (2^16‑1) に制限します。ZIP64 形式拡張により、これらの制限は 2^64 まで緩和されます。

[IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) メソッドを使用すると、Office Open XML ファイルを保存する際に ZIP64 形式拡張を使用するタイミングを選択できます。

このメソッドは以下のモードで使用できます:

- `IfNecessary` は、プレゼンテーションが上記の制限を超える場合にのみ ZIP64 形式拡張を使用します。デフォルトのモードです。
- `Never` は ZIP64 形式拡張を一切使用しません。
- `Always` は常に ZIP64 形式拡張を使用します。

以下のコードは、ZIP64 形式拡張を有効にして PPTX としてプレゼンテーションを保存する方法を示しています。
```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```


{{% alert title="NOTE" color="warning" %}}
`Zip64Mode.Never` で保存すると、プレゼンテーションを ZIP32 形式で保存できない場合に [PptxException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxexception/) がスローされます。
{{% /alert %}}

## **サムネイルを更新せずにプレゼンテーションを保存**

[PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) メソッドは、プレゼンテーションを PPTX に保存する際のサムネイル生成を制御します:

- `true` に設定すると、保存時にサムネイルが更新されます。これがデフォルトです。
- `false` に設定すると、現在のサムネイルが保持されます。プレゼンテーションにサムネイルがない場合は生成されません。

以下のコードでは、サムネイルを更新せずに PPTX としてプレゼンテーションが保存されます。
```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```


{{% alert title="Info" color="info" %}}
このオプションは、PPTX 形式でプレゼンテーションを保存するのにかかる時間を短縮するのに役立ちます。
{{% /alert %}}

## **保存時の進捗をパーセンテージで取得**

[IProgressCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iprogresscallback/) インターフェイスは、[ISaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/isaveoptions/) インターフェイスが公開する `set_ProgressCallback` メソッドおよび抽象クラス [SaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/) を通じて使用されます。`set_ProgressCallback` で [IProgressCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iprogresscallback/) の実装を割り当てると、保存進捗がパーセンテージで更新されます。

以下のコードスニペットは `IProgressCallback` の使用方法を示しています。
```cpp
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue)
    {
        // ここで進捗のパーセンテージ値を使用します。
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```

```cpp
auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```


{{% alert title="Info" color="info" %}}
Aspose は独自の API を使用した [無料の PowerPoint Splitter アプリ](https://products.aspose.app/slides/splitter) を開発しました。このアプリは、選択したスライドを新しい PPTX または PPT ファイルとして保存することで、プレゼンテーションを複数のファイルに分割できます。
{{% /alert %}}

## **FAQ**

**「高速保存」（インクリメンタル保存）は、変更分だけを書き込むことがサポートされていますか？**

いいえ。保存は毎回完全なターゲットファイルを作成します。インクリメンタルの「高速保存」はサポートされていません。

**同じ Presentation インスタンスを複数のスレッドから保存することはスレッドセーフですか？**

いいえ。[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) インスタンスは [スレッドセーフではありません](/slides/ja/cpp/multithreading/)。単一のスレッドから保存してください。

**保存時にハイパーリンクや外部リンクされたファイルはどうなりますか？**

[ハイパーリンク](/slides/ja/cpp/manage-hyperlinks/) は保持されます。外部リンクされたファイル（例：相対パスで参照される動画）は自動的にコピーされません—参照パスが引き続きアクセス可能であることを確認してください。

**ドキュメントのメタデータ（作者、タイトル、会社、日付）を設定/保存できますか？**

はい。標準の [ドキュメント プロパティ](/slides/ja/cpp/presentation-properties/) がサポートされており、保存時にファイルに書き込まれます。