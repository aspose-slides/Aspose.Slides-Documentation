---
title: プレゼンテーションの調査
type: docs
weight: 30
url: /ja/python-net/examine-presentation/
keywords:
- PowerPoint
- プレゼンテーション
- プレゼンテーションフォーマット
- プレゼンテーションプロパティ
- ドキュメントプロパティ
- プロパティの取得
- プロパティの読み込み
- プロパティの変更
- プロパティの修正
- PPTX
- PPT
- Python
description: "PythonでPowerPointプレゼンテーションプロパティを読み取り、修正する"
---

Aspose.Slides for Python via .NETを使用すると、プレゼンテーションを調査してそのプロパティを知り、その動作を理解できます。

{{% alert title="情報" color="info" %}} 

[PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/)および[DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/)クラスには、ここでの操作に使用されるプロパティとメソッドが含まれています。

{{% /alert %}} 

## **プレゼンテーションフォーマットの確認**

プレゼンテーションに取り組む前に、現在プレゼンテーションがどのフォーマット（PPT、PPTX、ODPなど）であるかを確認したい場合があります。

プレゼンテーションを読み込まずに、プレゼンテーションのフォーマットを確認できます。以下のPythonコードを参照してください。

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **プレゼンテーションプロパティの取得**

このPythonコードは、プレゼンテーションプロパティ（プレゼンテーションに関する情報）を取得する方法を示しています。

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

[DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/#properties)クラスのプロパティを確認したい場合があります。

## **プレゼンテーションプロパティの更新**

Aspose.Slidesは、プレゼンテーションプロパティを変更することを可能にする[PresentationInfo.update_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties)メソッドを提供します。

PowerPointプレゼンテーションが以下に示すドキュメントプロパティを持っているとしましょう。

![PowerPointプレゼンテーションの元のドキュメントプロパティ](input_properties.png)

このコード例は、いくつかのプレゼンテーションプロパティを編集する方法を示しています。

```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "私のタイトル"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

ドキュメントプロパティを変更した結果は以下に示されています。

![PowerPointプレゼンテーションの変更されたドキュメントプロパティ](output_properties.png)

## **便利なリンク**

プレゼンテーションやそのセキュリティ属性に関する詳細情報を得るために、以下のリンクが役立つかもしれません。

- [プレゼンテーションが暗号化されているかどうかの確認](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [プレゼンテーションが書き込み保護されているかどうかの確認（読み取り専用）](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [プレゼンテーションを読み込む前にパスワード保護されているかどうかを確認する](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [プレゼンテーションを保護するために使用されたパスワードの確認](https://docs.aspose.com/slides/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation)