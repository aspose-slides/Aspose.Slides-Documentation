---
title: プレゼンテーションの確認 - C++ PowerPoint API
linktitle: プレゼンテーションの確認
type: docs
weight: 30
url: /cpp/examine-presentation/
keywords:
- PowerPoint
- プレゼンテーション
- プレゼンテーションフォーマット
- プレゼンテーションプロパティ
- ドキュメントプロパティ
- プロパティを取得
- プロパティを読み取る
- プロパティを変更
- プロパティを修正
- PPTX
- PPT
- C++
description: "C++でPowerPointプレゼンテーションプロパティを読み取り、変更する"
---

Aspose.Slides for C++を使用すると、プレゼンテーションを確認してそのプロパティを把握し、動作を理解できます。 

{{% alert title="情報" color="info" %}}

[TPresentationInfo](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation_info)および[DocumentProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.document_properties/)クラスは、ここでの操作に使用されるプロパティとメソッドを含んでいます。

{{% /alert %}} 

## **プレゼンテーションフォーマットの確認**

プレゼンテーションに取り組む前に、現在のプレゼンテーションのフォーマット（PPT、PPTX、ODPなど）を確認したい場合があります。

プレゼンテーションを読み込まずに、プレゼンテーションのフォーマットを確認できます。次のC++コードを参照してください：

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **プレゼンテーションプロパティの取得**

このC++コードは、プレゼンテーションプロパティ（プレゼンテーションに関する情報）を取得する方法を示しています：

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// .. 
```

## **プレゼンテーションプロパティの更新**

Aspose.Slidesは、プレゼンテーションプロパティを変更できる[PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentationinfo/updatedocumentproperties/)メソッドを提供します。

たとえば、以下のドキュメントプロパティを持つPowerPointプレゼンテーションがあるとします。

![PowerPointプレゼンテーションの元のドキュメントプロパティ](input_properties.png)

このコード例は、いくつかのプレゼンテーションプロパティを編集する方法を示しています：

```cpp
auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"私のタイトル");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

ドキュメントプロパティを変更した結果は以下の通りです。

![PowerPointプレゼンテーションの変更されたドキュメントプロパティ](output_properties.png)

## **役立つリンク**

プレゼンテーションおよびそのセキュリティ属性に関する詳細情報を得るために、以下のリンクが役立つ場合があります：

- [プレゼンテーションが暗号化されているかどうかの確認](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [プレゼンテーションが書き込み保護されているかどうかの確認（読み取り専用）](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [プレゼンテーションを読み込む前にパスワード保護されているかどうかの確認](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [プレゼンテーションを保護するために使用されるパスワードの確認](https://docs.aspose.com/slides/cpp/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).