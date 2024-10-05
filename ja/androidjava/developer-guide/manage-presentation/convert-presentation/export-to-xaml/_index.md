---
title: XAMLへのエクスポート
type: docs
weight: 30
url: /androidjava/export-to-xaml/

---

# プレゼンテーションをXAMLにエクスポートする

{{% alert color="primary" %}} 

[Aspose.Slides 21.6](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-21-6-release-notes/)では、XAMLエクスポートのサポートを実装しました。これで、プレゼンテーションをXAMLにエクスポートできるようになりました。

{{% /alert %}} 

# XAMLについて

XAMLは、アプリのユーザーインターフェイスを構築または記述するための記述的プログラミング言語であり、特にWPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）、およびXamarinフォームを使用するアプリに使われます。  

XAMLはXMLベースの言語であり、MicrosoftのGUI記述用のバリアントです。XAMLファイルに取り組む際には、デザイナーを使用することが多いですが、GUIを手動で記述および編集することもできます。

## デフォルトオプションを使用してプレゼンテーションをXAMLにエクスポートする

以下のJavaコードは、デフォルト設定でプレゼンテーションをXAMLにエクスポートする方法を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## カスタムオプションを使用してプレゼンテーションをXAMLにエクスポートする

[IXamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions)インターフェイスからオプションを選択して、エクスポートプロセスを制御し、Aspose.SlidesがプレゼンテーションをXAMLにエクスポートする方法を決定することができます。

たとえば、Aspose.Slidesにプレゼンテーションから隠れたスライドをXAMLにエクスポートする際に追加させたい場合は、[ExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-)プロパティをtrueに設定できます。以下は、このサンプルJavaコードです：

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