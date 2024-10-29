---
title: プレゼンテーションフォーマット
type: docs
weight: 10
url: /ja/net/presentation-format/
---

Aspose.Slides for .NETは、ロードする前にプレゼンテーションフォーマットを取得するために使用される[**PresentationFactory**](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory)クラスを提供します。

プレゼンテーションフォーマットを取得するには、以下の手順を実行してください。

1. [**IPresentationInfo**](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo)クラスのインスタンスを作成します。
1. プレゼンテーションフォーマットに関する情報を取得します。

以下の例では、プレゼンテーションフォーマットを取得しています。

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("HelloWorld.pptx");
switch (info.LoadFormat)
{
    case LoadFormat.Pptx:
        {
            break;
        }

    case LoadFormat.Unknown:
        {
            break;
        }
}
```