---
title: プレゼンテーションへの保護の適用
type: docs
weight: 60
url: /ja/java/applying-protection-to-presentation/
---

{{% alert color="primary" %}} 

Aspose.Slidesの一般的な使用法は、自動化されたワークフローの一環としてMicrosoft PowerPoint 2007 (PPTX) プレゼンテーションを作成、更新、保存することです。この方法でAspose.Slidesを使用するアプリケーションのユーザーは、出力されたプレゼンテーションにアクセスできます。これらを編集から保護することは一般的な懸念事項です。自動生成されたプレゼンテーションが元のフォーマットと内容を保持することが重要です。

この記事では、[プレゼンテーションとスライドの構成](/slides/ja/java/applying-protection-to-presentation/)と、Aspose.Slides for Javaが[保護を適用する方法](/slides/ja/java/applying-protection-to-presentation/)および[保護を解除する方法](/slides/ja/java/applying-protection-to-presentation/)について説明します。この機能はAspose.Slidesに特有のもので、執筆時点ではMicrosoft PowerPointには存在しません。これにより、開発者は彼らのアプリケーションが作成するプレゼンテーションがどのように使用されるかを制御できます。

{{% /alert %}} 
## **スライドの構成**
PPTXスライドは、自動図形、表、OLEオブジェクト、グループ化された図形、画像フレーム、ビデオフレーム、コネクタ、およびプレゼンテーションを構築するために使用できるさまざまな要素など、多くのコンポーネントで構成されています。Aspose.Slides for Javaでは、スライド上の各要素はShapeオブジェクトに変換されます。言い換えれば、スライド上の各要素はShapeオブジェクトまたはShapeオブジェクトから派生したオブジェクトです。PPTXの構造は複雑であるため、すべての種類の図形に対して一般的なロックを使用できるPPTとは異なり、さまざまな種類の図形タイプに対して異なる種類のロックがあります。BaseShapeLockクラスは、一般的なPPTXロッキングクラスです。Aspose.Slides for JavaでサポートされているPPTXのロックタイプは以下の通りです。

- AutoShapeLockは自動図形をロックします。
- ConnectorLockはコネクター図形をロックします。
- GraphicalObjectLockはグラフィカルオブジェクトをロックします。
- GroupshapeLockはグループ図形をロックします。
- PictureFrameLockは画像フレームをロックします。
  プレゼンテーションオブジェクト内のすべてのShapeオブジェクトに対して実行されるアクションは、プレゼンテーション全体に適用されます。
## **保護の適用と解除**
保護を適用することにより、プレゼンテーションが編集できなくなります。これは、プレゼンテーションの内容を保護するための便利な手法です。
## **PPTX図形への保護の適用**
Aspose.Slides for Javaは、スライド上の図形を扱うためにShapeクラスを提供します。

前述のように、各図形クラスには保護のための関連する図形ロッククラスがあります。この記事では、NoSelect、NoMove、およびNoResizeロックに焦点を当てています。これらのロックは、図形が選択できない（マウスクリックまたは他の選択方法を通じて）、移動したりサイズを変更したりできないことを保証します。

続くコードサンプルは、プレゼンテーション内のすべての図形タイプに保護を適用します。



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-ApplyProtection-ApplyProtection.java" >}}
## **保護の解除**
Aspose.Slides for .NET/Javaを使用して適用された保護は、Aspose.Slides for .NET/Javaを使わなければ解除できません。図形のロックを解除するには、適用されたロックの値をfalseに設定します。以下のコードサンプルは、ロックされたプレゼンテーション内の図形のロックを解除する方法を示しています。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-RemoveProtection-RemoveProtection.java" >}}



## **まとめ**
{{% alert color="primary" %}} 

Aspose.Slidesは、プレゼンテーション内の図形に保護を適用するための多くのオプションを提供します。特定の図形をロックすることも、プレゼンテーション内のすべての図形をループしてすべてをロックし、実質的にプレゼンテーションをロックすることも可能です。Aspose.Slides for Javaのみが以前に保護されたプレゼンテーションから保護を解除できます。ロックの値をfalseに設定して保護を解除します。

{{% /alert %}}