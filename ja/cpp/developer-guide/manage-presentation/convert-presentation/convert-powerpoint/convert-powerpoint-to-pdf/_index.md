---
title: C++ で PPT と PPTX を PDF に変換 [高度な機能を含む]
linktitle: PowerPoint を PDF に変換
type: docs
weight: 40
url: /ja/cpp/convert-powerpoint-to-pdf/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- PowerPoint から PDF へ
- プレゼンテーションから PDF へ
- PPT を PDF に
- PPT を PDF に変換
- PPTX を PDF に
- PPTX を PDF に変換
- PowerPoint を PDF として保存
- PPT を PDF として保存
- PPTX を PDF として保存
- PPT を PDF にエクスポート
- PPTX を PDF にエクスポート
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して、C++ で PowerPoint の PPT/PPTX を高品質かつ検索可能な PDF に変換します。高速なコード例と高度な変換オプションを提供します。"
---
## **概要**

PowerPoint プレゼンテーション（PPT、PPTX、ODP など）を C++ で PDF 形式に変換すると、デバイス間の互換性やプレゼンテーションのレイアウト・書式を保持できるなど、さまざまな利点があります。本ガイドでは、プレゼンテーションを PDF に変換する方法、画像品質を制御するオプションの使用、非表示スライドの含め方、PDF ファイルへのパスワード保護、フォント置換の検出、特定スライドの選択変換、出力ドキュメントへのコンプライアンス標準の適用方法を示します。

## **PowerPoint を PDF に変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、ファイル名を引数として [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスに渡し、`Save` メソッドで PDF として保存します。[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスは、通常 PDF への変換に使用される `Save` メソッドを公開しています。

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for C++ は、出力ドキュメントに API 情報とバージョン番号を挿入します。たとえば、プレゼンテーションを PDF に変換する場合、Application フィールドに「*Aspose.Slides*」が、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」形式の値が設定されます。**Note** この情報を出力ドキュメントから変更または削除するよう指示することはできません。

{{% /alert %}}

Aspose.Slides は次の変換をサポートします：

* プレゼンテーション全体を PDF に変換
* プレゼンテーションの特定スライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、生成された PDF が元のプレゼンテーションに極めて近い形になるようにします。変換時に正確にレンダリングされる要素と属性は以下の通りです。

* 画像
* テキスト ボックスと図形
* テキストの書式設定
* 段落の書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPoint を PDF に変換**

標準の PowerPoint → PDF 変換プロセスはデフォルトオプションを使用します。この場合、Aspose.Slides は最大品質レベルで最適な設定を用いてプレゼンテーションを PDF に変換しようとします。

以下の C++ コードは、プレゼンテーション（PPT、PPTX、ODP など）を PDF に変換する方法を示しています。

```c++
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// プレゼンテーションを PDF として保存します。
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 

Aspose は、プレゼンテーション → PDF 変換プロセスをデモンストレーションする無料のオンライン **PowerPoint to PDF converter**(https://products.aspose.app/slides/ja/conversion/ppt-to-pdf) を提供しています。このコンバータでテストを実行すれば、本稿で説明した手順をライブで確認できます。

{{% /alert %}}

## **オプション付きで PowerPoint を PDF に変換**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/pdfoptions/) クラスのプロパティとしてカスタムオプションを提供し、生成される PDF のカスタマイズ、パスワードロック、変換処理の進め方を指定できます。

### **カスタムオプションで PowerPoint を PDF に変換**

カスタム変換オプションを使用すると、ラスター画像の品質設定、メタファイルの取り扱い方法、テキストの圧縮レベル、画像の DPI などを自由に定義できます。

以下のコード例は、複数のカスタムオプションを使用して PowerPoint プレゼンテーションを PDF に変換する方法を示しています。

```c++
// PdfOptions クラスのインスタンスを作成します。
auto pdfOptions = MakeObject<PdfOptions>();

// JPG 画像の品質を設定します。
pdfOptions->set_JpegQuality(90);

// 画像の DPI を設定します。
pdfOptions->set_SufficientResolution(300);

// メタファイルの動作を設定します。
pdfOptions->set_SaveMetafilesAsPng(true);

// テキスト コンテンツの圧縮レベルを設定します。
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// PDF コンプライアンスモードを定義します。
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// プレゼンテーションを PDF ドキュメントとして保存します。
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **非表示スライド付きで PowerPoint を PDF に変換**

プレゼンテーションに非表示スライドが含まれる場合、[PdfOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/pdfoptions/) クラスの [set_ShowHiddenSlides](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) メソッドを使用して、非表示スライドを生成される PDF のページとして含めることができます。

以下の C++ コードは、非表示スライドを含めて PowerPoint プレゼンテーションを PDF に変換する方法を示しています。

```c++
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// PdfOptions クラスのインスタンスを作成します。
auto pdfOptions = MakeObject<PdfOptions>();

// 非表示スライドを追加します。
pdfOptions->set_ShowHiddenSlides(true);

// プレゼンテーションを PDF として保存します。
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **パスワード保護された PDF に PowerPoint を変換**

この C++ コードは、[PdfOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/pdfoptions/) クラスの保護パラメータを使用して、PowerPoint プレゼンテーションをパスワード保護された PDF に変換する方法を示します。

```c++
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// PdfOptions クラスのインスタンスを作成します。
auto pdfOptions = MakeObject<PdfOptions>();

// PDF のパスワードとアクセス許可を設定します。
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// プレゼンテーションを PDF として保存します。
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **フォント置換の検出**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/pdfoptions/) クラス配下の [set_WarningCallback](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/saveoptions/set_warningcallback/) メソッドを提供し、プレゼンテーション → PDF 変換プロセス中のフォント置換を検出できます。

以下の C++ コードは、フォント置換を検出する方法を示しています。

```c++
// 警告コールバックの実装。
class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontSubstitutionHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss && 
        warning->get_Description().StartsWith(u"Font will be substituted"))
    {
        Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
    }

    return ReturnAction::Continue;
}

int main()
{
    // PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // PDF オプションで警告コールバックを設定します。
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // プレゼンテーションを PDF として保存します。
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```

{{%  alert color="primary"  %}} 

レンダリング中にフォント置換のコールバックを受け取る方法の詳細は、[Getting Warning Callbacks for Fonts Substitution](/slides/ja/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) を参照してください。

フォント置換に関する詳細は、[Font Substitution](/slides/ja/cpp/font-substitution/) 記事をご覧ください。

{{% /alert %}} 

## **PowerPoint から選択したスライドだけを PDF に変換**

以下の C++ コードは、PowerPoint プレゼンテーションから特定のスライドだけを PDF に変換する方法を示しています。

```C++
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// スライド番号の配列を設定します。
auto slides = MakeArray<int32_t>({ 1, 3 });

// プレゼンテーションを PDF として保存します。
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **カスタムスライドサイズで PowerPoint を PDF に変換**

以下の C++ コードは、指定したスライドサイズで PowerPoint プレゼンテーションを PDF に変換する方法を示しています。

```C++
auto slideWidth = 612;
auto slideHeight = 792;

// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// 調整されたスライドサイズで新しいプレゼンテーションを作成します。
auto resizedPresentation = MakeObject<Presentation>();

// カスタムスライドサイズを設定します。
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// 元のプレゼンテーションから最初のスライドをクローンします。
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// リサイズしたプレゼンテーションをノート付きの PDF として保存します。
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **ノートスライドビューで PowerPoint を PDF に変換**

以下の C++ コードは、ノートを含む PDF を生成するために PowerPoint プレゼンテーションを変換する方法を示しています。

```C++
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Configure the PDF options with Notes Layout.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to a PDF with notes.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **PDF のアクセシビリティとコンプライアンス標準**

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できます。次のコンプライアンス標準のいずれかを使用して、PowerPoint ドキュメントを PDF にエクスポートできます：**PDF/A1a**、**PDF/A1b**、**PDF/UA**。

以下の C++ コードは、異なるコンプライアンス標準に基づいて複数の PDF を生成する PowerPoint → PDF 変換プロセスを示しています。

```C++
auto presentation = MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = MakeObject<PdfOptions>();

pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
presentation->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
presentation->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);

presentation->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);

presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides は PDF 変換操作もサポートしており、PDF ファイルを一般的なフォーマットに変換できます。[PDF to HTML](https://products.aspose.com/slides/ja/cpp/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/ja/cpp/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/ja/cpp/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/ja/cpp/conversion/pdf-to-png/) 変換が可能です。さらに、[PDF to SVG](https://products.aspose.com/slides/ja/cpp/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/ja/cpp/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/ja/cpp/conversion/pdf-to-xml/) などの特殊フォーマットへの変換もサポートされています。

{{% /alert %}}

> **Note:** PDF/UA にエクスポートする場合、Aspose.Slides は SmartArt、チャート、数式などの複雑なグラフィックを単一の図形として扱います。個々のパス要素は別個のコンテンツとして保持されず、アーティファクトとしてマークされる可能性があります。代替テキストは全体の図形に対してのみ提供されます。

## **よくある質問**

**複数の PowerPoint ファイルを一括で PDF に変換できますか？**

はい、Aspose.Slides は複数の PPT または PPTX ファイルをバッチ変換して PDF にすることをサポートしています。ファイルを列挙し、プログラム的に変換処理を適用できます。

**変換後の PDF にパスワード保護を設定できますか？**

もちろんです。[PdfOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/pdfoptions/) クラスを使用して、変換時にパスワードとアクセス権限を設定できます。

**PDF に非表示スライドを含めるにはどうすればよいですか？**

[PdfOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/pdfoptions/) クラスの `set_ShowHiddenSlides` メソッドを使用して、生成される PDF に非表示スライドを含めることができます。

**Aspose.Slides は PDF で高画質の画像を維持できますか？**

はい、`set_JpegQuality` や `set_SufficientResolution` などのメソッドを [PdfOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/pdfoptions/) クラスで使用すれば、PDF 内の画像品質を高く保つことができます。

**Aspose.Slides は PDF/A コンプライアンス標準をサポートしていますか？**

はい、Aspose.Slides は PDF/A1a、PDF/A1b、PDF/UA などのさまざまな標準に準拠した PDF のエクスポートをサポートしており、アクセシビリティとアーカイブ要件を満たすことができます。

## **追加リソース**

- [Aspose.Slides for C++ ドキュメント](/slides/ja/cpp/)
- [Aspose.Slides for C++ API リファレンス](https://reference.aspose.com/slides/ja/cpp/)
- [Aspose 無料オンラインコンバータ](https://products.aspose.app/slides/ja/conversion)