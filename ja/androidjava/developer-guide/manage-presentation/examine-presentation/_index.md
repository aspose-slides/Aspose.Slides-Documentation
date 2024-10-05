---
title: プレゼンテーションの調査
type: docs
weight: 30
url: /androidjava/examine-presentation/
keywords:
- PowerPoint
- プレゼンテーション
- プレゼンテーション形式
- プレゼンテーションのプロパティ
- ドキュメントのプロパティ
- プロパティを取得
- プロパティを読み取る
- プロパティを変更
- プロパティを修正
- PPTX
- PPT
- Android
- Java
description: "Javaを通じてAndroidでPowerPointプレゼンテーションのプロパティを読み取り、変更します"
---

Aspose.Slides for Android via Javaを使用すると、プレゼンテーションを調査してそのプロパティを見つけ、その動作を理解することができます。

{{% alert title="情報" color="info" %}} 

[PresentationInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PresentationInfo)および[DocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/)クラスには、ここでの操作に使用されるプロパティとメソッドが含まれています。

{{% /alert %}} 

## **プレゼンテーション形式の確認**

プレゼンテーションに取り組む前に、プレゼンテーションが現在どの形式（PPT、PPTX、ODPなど）であるかを確認したい場合があります。

プレゼンテーションを読み込まずに、その形式を確認できます。以下のJavaコードをご覧ください：

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **プレゼンテーションのプロパティを取得**

このJavaコードは、プレゼンテーションのプロパティ（プレゼンテーションに関する情報）を取得する方法を示しています：

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

[DocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--)クラスの下にあるプロパティも確認することをお勧めします。

## **プレゼンテーションのプロパティを更新**

Aspose.Slidesは、プレゼンテーションのプロパティを変更できる[PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)メソッドを提供しています。

PowerPointプレゼンテーションに、以下のドキュメントプロパティが表示されているとしましょう。

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

ドキュメントプロパティを変更した結果が以下に示されています。

![変更されたPowerPointプレゼンテーションのドキュメントプロパティ](output_properties.png)

## **役に立つリンク**

プレゼンテーションとそのセキュリティ属性についての詳細情報を得るために、以下のリンクが役立つかもしれません：

- [プレゼンテーションが暗号化されているかどうかを確認する](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [プレゼンテーションが書き込み保護されているかどうかを確認する（読み取り専用）](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [読み込む前にプレゼンテーションがパスワードで保護されているかどうかを確認する](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [プレゼンテーションを保護するために使用されるパスワードを確認する](https://docs.aspose.com/slides/androidjava/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).