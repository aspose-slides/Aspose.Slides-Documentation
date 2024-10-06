---
title: 読み取り専用プレゼンテーション
type: docs
weight: 30
url: /ja/python-net/read-only-presentation/
keywords: "読み取り専用設定, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "Pythonにおける読み取り専用のPowerPointプレゼンテーション"
---

PowerPoint 2019では、Microsoftがユーザーがプレゼンテーションを保護するために使用できるオプションの1つとして**常に読み取り専用で開く**設定を導入しました。この読み取り専用設定を使用してプレゼンテーションを保護したい場合、次のような理由があります。

- 誤って編集されることを防ぎ、プレゼンテーションの内容を安全に保ちたい。 
- 提供したプレゼンテーションが最終版であることを人々に知らせたい。 

プレゼンテーションに**常に読み取り専用で開く**オプションを選択すると、ユーザーがプレゼンテーションを開いたときに**読み取り専用**の推奨が表示され、次のようなメッセージが表示される場合があります：*誤って変更を防ぐために、著者はこのファイルを読み取り専用で開くように設定しました。*

読み取り専用の推奨は、編集を思いとどまらせるシンプルで効果的な抑止力です。なぜなら、ユーザーがプレゼンテーションを編集する前にそれを解除する作業を行う必要があるからです。プレゼンテーションに変更を加えてほしくなく、丁寧にその旨を伝えたい場合、読み取り専用の推奨は良い選択肢かもしれません。

> **読み取り専用**保護がかけられたプレゼンテーションを、最近導入された機能をサポートしていない古いMicrosoft PowerPointアプリケーションで開くと、**読み取り専用**の推奨は無視されます（プレゼンテーションは通常通り開かれます）。

Aspose.Slides for Python via .NETを使用すると、プレゼンテーションを**読み取り専用**として設定でき、ユーザーは（プレゼンテーションを開いた後に）**読み取り専用**の推奨を確認します。このサンプルコードは、Aspose.Slidesを使用してPythonでプレゼンテーションを**読み取り専用**に設定する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

**注意**：**読み取り専用**の推奨は、単に編集を思いとどまらせたり、ユーザーがPowerPointプレゼンテーションに誤って変更を加えるのを防ぐことを目的としています。もし、何をしているのかを知っている意欲的な人があなたのプレゼンテーションを編集することを決意した場合、彼らは簡単に読み取り専用設定を解除することができます。無許可の編集を本当に防ぎたい場合は、[暗号化やパスワードを伴うより厳格な保護を使用した方が良いです](https://docs.aspose.com/slides/python-net/password-protected-presentation/)。 

{{% /alert %}}