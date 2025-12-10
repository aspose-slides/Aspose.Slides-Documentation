---
title: C++ でプレゼンテーション情報を取得および更新
linktitle: プレゼンテーション情報
type: docs
weight: 30
url: /ja/cpp/examine-presentation/
keywords:
- プレゼンテーション形式
- プレゼンテーションプロパティ
- ドキュメントプロパティ
- プロパティ取得
- プロパティ読み取り
- プロパティ変更
- プロパティ修正
- プロパティ更新
- PPTX を調査
- PPT を調査
- ODP を調査
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ を使用して PowerPoint および OpenDocument プレゼンテーションのスライド、構造、メタデータを調査し、迅速な洞察とスマートなコンテンツ監査を実現します。"
---

Aspose.Slides for C++ を使用すると、プレゼンテーションを調べてそのプロパティを把握し、動作を理解できます。 

{{% alert title="Info" color="info" %}}
ここで使用される操作に必要なプロパティとメソッドを含むのは、[PresentationInfo](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation_info) と [DocumentProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.document_properties/) クラスです。
{{% /alert %}} 

## **プレゼンテーション形式の確認**

プレゼンテーションを操作する前に、現在のプレゼンテーションがどの形式（PPT、PPTX、ODP など）であるかを確認したい場合があります。

プレゼンテーションをロードせずに形式を確認できます。以下の C++ コードをご覧ください。
``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX形式
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT形式
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP形式
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```


## **プレゼンテーション プロパティの取得**

この C++ コードは、プレゼンテーションのプロパティ（プレゼンテーションに関する情報）を取得する方法を示しています。
``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// .. 
```


## **プレゼンテーション プロパティの更新**

Aspose.Slides は、プレゼンテーションのプロパティを変更できる [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) メソッドを提供します。

以下のように、ドキュメントプロパティが表示された PowerPoint プレゼンテーションがあるとします。

![PowerPoint プレゼンテーションの元のドキュメントプロパティ](input_properties.png)

このコード例は、いくつかのプレゼンテーションプロパティを編集する方法を示しています。
```cpp
auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```


ドキュメントプロパティを変更した結果は以下のとおりです。

![PowerPoint プレゼンテーションの変更後ドキュメントプロパティ](output_properties.png)

## **便利なリンク**

プレゼンテーションとそのセキュリティ属性に関する詳細情報を得るために、以下のリンクが役立つ場合があります：

- [プレゼンテーションが暗号化されているかの確認](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [プレゼンテーションが書き込み保護（読み取り専用）かの確認](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [ロード前にプレゼンテーションがパスワードで保護されているかの確認](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [プレゼンテーションを保護するために使用されたパスワードの確認](https://docs.aspose.com/slides/cpp/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **よくある質問**

**フォントが埋め込まれているか、どのフォントが埋め込まれているかを確認するにはどうすればよいですか？**

プレゼンテーションレベルで [embedded-font information](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getembeddedfonts/) を探し、次にそれらのエントリを [実際にコンテンツで使用されているフォント](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getfonts/) と比較して、レンダリングに重要なフォントを特定します。

**ファイルに非表示スライドがあるか、またその数をすばやく確認するにはどうすればよいですか？**

[スライドコレクション](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/) を反復処理し、各スライドの [可視性フラグ](https://reference.aspose.com/slides/cpp/aspose.slides/slide/get_hidden/) をチェックします。

**カスタム スライド サイズと向きが使用されているか、デフォルトと異なるかどうかを検出できますか？**

はい。現在の [スライドサイズと向き](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slidesize/) を標準のプリセットと比較してください。これにより、印刷やエクスポート時の動作を予測できます。

**チャートが外部データソースを参照しているかどうかをすばやく確認する方法はありますか？**

はい。すべての [チャート](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/) を走査し、各チャートの [データ ソース](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) を確認して、データが内部かリンクベースか、壊れたリンクがあるかどうかをメモします。

**レンダリングや PDF エクスポートを遅くする可能性のある「重い」スライドを評価するにはどうすればよいですか？**

各スライドについて、オブジェクト数を集計し、大きな画像、透明性、シャドウ、アニメーション、マルチメディアなどをチェックします。その後、概算の複雑度スコアを割り当て、パフォーマンス上のホットスポットになる可能性があるスライドをフラグ付けします。