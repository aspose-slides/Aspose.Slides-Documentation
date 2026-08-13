---
title: Aspose.Slides for .NET 14.2.0 の公開 API と下位互換性のない変更
linktitle: Aspose.Slides for .NET 14.2.0
type: docs
weight: 40
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- 移行
- レガシーコード
- モダンコード
- レガシーアプローチ
- モダンアプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET の公開 API の更新と破壊的変更を確認し、PowerPoint PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---
## **公開 API と下位互換性のない変更**
{{% alert color="info" %}} 

Aspose.Slides for .NET 14.2.0 API にいくつか変更を加えました。一部のプロパティとメソッドが削除され、いくつかは別の名前空間に移動しました。

{{% /alert %}} 
### **Methods Aspose.Slides.IPresentation.Write(…) Removed**
これらのメソッドは Presentation オブジェクトを PPTX 形式のファイルにのみ書き出していました。新しい API では、Presentation クラスはすべての形式での操作に使用されます。Presentation.Save(…) メソッドを使用して、Presentation オブジェクトをすべてのサポート対象形式に保存できます。
### **Classes Related to Theme Styles Moved to the Aspose.Slides.Theme Namespace**
以下のクラスは Aspose.Slides 名前空間から Aspose.Slides.Theme 名前空間へ移動しました。

- Types ColorScheme
- EffectStyle
- EffectStyleCollection
- EffectStyleCollectionEffectiveData
- ExtraColorSchemeCollection
- ExtraColorSchemeCollection
- ExtraColorScheme
- FillFormatCollection
- FillFormatCollectionEffectiveData
- FontScheme
- FontSchemeEffectiveData
- FormatScheme
- IColorScheme
- IEffectStyle
- IEffectStyleCollection
- IEffectStyleCollectionEffectiveData
- IEffectStyleEffectiveData
- IExtraColorScheme
- IExtraColorSchemeCollection
- IFillFormatCollection
- IFillFormatCollectionEffectiveData
- IFontScheme
- IFontSchemeEffectiveData
- IFormatScheme
- ILineFormatCollection
- ILineFormatCollectionEffectiveData
### **Changes from Aspose.Slides for .NET 8.X.0**
Aspose.Slides for .NET 8.4 の機能が Aspose.Slides for .NET 14.2.0 に追加されました