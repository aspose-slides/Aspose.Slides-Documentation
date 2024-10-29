---
title: Aspose.Slides for .NET 14.2.0の公開APIと後方互換性のない変更
type: docs
weight: 40
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
---

## **公開APIと後方互換性のない変更**
{{% alert color="primary" %}} 

Aspose.Slides for .NET 14.2.0 APIにいくつかの変更を加えました。いくつかのプロパティとメソッドが削除され、一部は他の名前空間に移動されました。

{{% /alert %}} 
### **Aspose.Slides.IPresentation.Write(…) メソッドが削除されました**
これらのメソッドは、プレゼンテーションオブジェクトをPPTX形式のファイルにのみ書き込んでいました。新しいAPIでは、Presentationクラスはすべての形式での作業に使用されます。Presentation.Save(…)メソッドを使用して、すべてのサポートされている形式にプレゼンテーションオブジェクトを保存することができます。
### **テーマスタイルに関連するクラスがAspose.Slides.Theme名前空間に移動されました**
以下のクラスはAspose.Slides名前空間からAspose.Slides.Theme名前空間に移動されました。

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
### **Aspose.Slides for .NET 8.X.0からの変更**
Aspose.Slides for .NET 8.4の機能がAspose.Slides for .NET 14.2.0に追加されました。