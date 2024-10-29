---
title: XAMLへのエクスポート
type: docs
weight: 30
url: /ja/java/export-to-xaml/

---

# プレゼンテーションをXAMLにエクスポートする

{{% alert color="primary" %}} 

[Aspose.Slides 21.6](https://docs.aspose.com/slides/java/aspose-slides-for-java-21-6-release-notes/)では、XAMLエクスポートのサポートを実装しました。これで、プレゼンテーションをXAMLにエクスポートできるようになりました。 

{{% /alert %}} 

# XAMLについて

XAMLは、アプリケーションのユーザーインターフェースを構築または記述するための記述的なプログラミング言語であり、特にWPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）、およびXamarinフォームを使用するアプリに適しています。

XAMLはXMLベースの言語であり、MicrosoftのGUIを記述するためのバリアントです。通常、デザイナーを使用してXAMLファイルに取り組むことが多いですが、自分でGUIを記述したり編集したりすることもできます。

## デフォルトオプションでのプレゼンテーションをXAMLにエクスポートする

このJavaコードは、デフォルト設定でプレゼンテーションをXAMLにエクスポートする方法を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## カスタムオプションでのプレゼンテーションをXAMLにエクスポートする

[IXamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/IXamlOptions)インターフェースからオプションを選択して、エクスポートプロセスを制御し、Aspose.SlidesがプレゼンテーションをXAMLにエクスポートする方法を決定できます。

たとえば、プレゼンテーションの隠れたスライドをXAMLにエクスポートする際にAspose.Slidesに追加させたい場合は、[ExportHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-)プロパティをtrueに設定できます。以下は、このサンプルJavaコードです：

```java
Presentation pres = new Presentation("pres.pptx");
try {
	XamlOptions xamlOptions = new XamlOptions();
	xamlOptions.setExportHiddenSlides(true);
	pres.save(xamlOptions);
} finally {
	if (pres != null) pres.dispose();
}
```