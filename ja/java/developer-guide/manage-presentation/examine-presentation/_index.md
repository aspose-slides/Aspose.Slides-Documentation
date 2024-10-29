---
title: プレゼンテーションの確認
type: docs
weight: 30
url: /ja/java/examine-presentation/
keywords:
- PowerPoint
- プレゼンテーション
- プレゼンテーション形式
- プレゼンテーションプロパティ
- ドキュメントプロパティ
- プロパティの取得
- プロパティの読み取り
- プロパティの変更
- プロパティの修正
- PPTX
- PPT
- Java
description: "JavaでPowerPointプレゼンテーションのプロパティを読み取り、変更する"
---

Aspose.Slides for Javaを使用すると、プレゼンテーションを調査し、そのプロパティを理解し、動作を把握できます。

{{% alert title="情報" color="info" %}} 

[PresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/PresentationInfo)および[DocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/documentproperties/)クラスには、ここでの操作に使用されるプロパティおよびメソッドが含まれています。

{{% /alert %}} 

## **プレゼンテーション形式の確認**

プレゼンテーションに取り組む前に、そのプレゼンテーションが現在どの形式（PPT、PPTX、ODPなど）であるかを確認したい場合があります。

プレゼンテーションを読み込むことなく、その形式を確認できます。以下のJavaコードを参照してください：

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **プレゼンテーションプロパティの取得**

以下のJavaコードは、プレゼンテーションのプロパティ（プレゼンテーションに関する情報）を取得する方法を示しています：

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

[DocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/documentproperties/#DocumentProperties--)クラスの下にあるプロパティも参照したいかもしれません。

## **プレゼンテーションプロパティの更新**

Aspose.Slidesは、プレゼンテーションプロパティに変更を加えるための[PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)メソッドを提供しています。

たとえば、以下のようなドキュメントプロパティを持つPowerPointプレゼンテーションがあるとします。

![PowerPointプレゼンテーションの元のドキュメントプロパティ](input_properties.png)

このコード例は、いくつかのプレゼンテーションプロパティを編集する方法を示しています：

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("私のタイトル");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

ドキュメントプロパティを変更した結果は以下に示されています。

![変更されたPowerPointプレゼンテーションのドキュメントプロパティ](output_properties.png)

## **便利なリンク**

プレゼンテーションおよびそのセキュリティ属性に関する詳細情報を得るには、以下のリンクが役立つかもしれません：

- [プレゼンテーションが暗号化されているかの確認](https://docs.aspose.com/slides/java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [プレゼンテーションが書き込み保護（読み取り専用）されているかの確認](https://docs.aspose.com/slides/java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [プレゼンテーションを読み込む前にパスワード保護されているかの確認](https://docs.aspose.com/slides/java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [プレゼンテーションを保護するために使用されたパスワードの確認](https://docs.aspose.com/slides/java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation)