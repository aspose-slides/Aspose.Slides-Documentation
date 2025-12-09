---
title: Aspose.Slides for .NET 14.2.0 のパブリック API と後方互換性のない変更
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
description: "Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションを円滑に移行できます。"
---

## **公開 API と後方互換性のない変更**
{{% alert color="primary" %}} 

Aspose.Slides for .NET 14.2.0 API でいくつか変更を行いました。プロパティやメソッドが削除されたものや、別の名前空間に移動されたものがあります。

{{% /alert %}} 
### **メソッド Aspose.Slides.IPresentation.Write(…) が削除されました**
これらのメソッドはプレゼンテーション オブジェクトを PPTX 形式のファイルにのみ書き出していました。新しい API では、Presentation クラスはすべての形式で操作できるようになっています。Presentation.Save(…) メソッドを使用して、プレゼンテーション オブジェクトをすべてのサポートされている形式に保存できます。
### **テーマ スタイルに関連するクラスが Aspose.Slides.Theme 名前空間に移動しました**
以下のクラスが Aspose.Slides 名前空間から Aspose.Slides.Theme 名前空間へ移動しました。

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
### **Aspose.Slides for .NET 8.X.0 からの変更**
Aspose.Slides for .NET 8.4 の機能が Aspose.Slides for .NET 14.2.0 に追加されました