---
title: PHPでシェイプロックを使用してプレゼンテーションの編集を制限する
linktitle: プレゼンテーションの編集を制限
type: docs
weight: 60
url: /ja/php-java/applying-protection-to-presentation/
keywords:
- 編集防止
- 編集から保護
- シェイプのロック
- 位置のロック
- 選択のロック
- サイズ変更のロック
- グループ化のロック
- PowerPoint
- PPTX
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して PPTX プレゼンテーション内のシェイプをロックおよびロック解除し、選択、移動、サイズ変更、グループ化を制限する方法を学びます。"
---
## **概要**

Aspose.Slides for PHP via Java の一般的な使用例は、PowerPoint（PPTX）プレゼンテーションを自動化されたワークフローの一部として作成、更新、保存することです。ユーザーがこれらのプレゼンテーションを受け取る際、図形への変更を制限することで、意図したレイアウトとコンテンツを保護できます。

この記事では、スライド上の図形の構成方法と、PPTX プレゼンテーションで図形ロックを適用および削除する方法について説明します。これらのロックにより、個々の図形に対する特定の編集操作を制限できます。

## **スライドの構成**

プレゼンテーションのスライドは、オートシェイプ、表、OLE オブジェクト、グループ化された図形、画像フレーム、ビデオフレーム、コネクタ、その他プレゼンテーションの構築に使用される要素で構成されています。Aspose.Slides for PHP via Java では、スライド上の各要素は、[Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) クラスを継承したオブジェクトとして表現されます。

図形の種類に応じて異なるロックオプションが提供されます。[BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) クラスは図形ロックの基底クラスです。Aspose.Slides for PHP via Java は、以下のロッククラスを提供します：

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) はオートシェイプをロックします。  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) はコネクタ形状をロックします。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) はグラフィカルオブジェクトをロックします。  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) はグループ形状をロックします。  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) は画像フレームをロックします。  

[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 全体にロックを適用するには、スライドを反復処理し、各サポートされている図形に適切なロックを設定します。

## **適用と保護の解除**

図形ロックは、図形の選択、移動、サイズ変更などの操作を制限します。これによりプレゼンテーション全体が編集不可能になるわけではありません。

### **PPTX 図形への保護の適用**

Aspose.Slides for PHP via Java は、スライド上の図形を操作するために [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) クラスを提供します。

この例では、オートシェイプに対して `true` を設定して [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked)、[setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked)、[setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) を呼び出し、グループ形状、コネクタ、画像フレームにも同等のロックを適用します。コネクタは移動のために [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) を使用し、グループは [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) を使用してグループ化を制限します。

この例では既存の PPTX プレゼンテーションを読み込み、各スライドのシェイプコレクション内の図形を確認し、これらの制限を適用したコピーを保存します。4 つの処理対象タイプ以外の図形は変更されません。ループはグループ内の子図形を走査しません。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(true);
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            }
        }
    }

    $presentation->save("ProtectedSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **保護の解除**

図形ロックを削除するには、その値を `false` に設定します。以下の例では、図形ロックが設定されたプレゼンテーションを読み込み、[AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/)・[GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/)・[ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/)・[PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) を介して選択・移動・サイズ変更の制限をクリアします。また、`false` を [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) に渡すことでグループ化の制限も解除し、プレゼンテーションのコピーを保存します。その他のロック設定は変更されません。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ProtectedSample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(false);
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            }
        }
    }

    $presentation->save("RemovedProtectionSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **結論**

Aspose.Slides for PHP via Java を使用すると、個々の図形に対して特定の編集操作を制限したり、スライド全体に同じ制限を適用したりできます。各図形タイプがサポートするロックを選択し、制限を解除する必要がある場合は値を `false` に設定します。

## **FAQ**

**同じプレゼンテーションで図形ロックとパスワード保護を組み合わせることはできますか？**

はい。図形ロックは特定の編集操作を制限し、[パスワード保護](/slides/ja/php-java/password-protected-presentation/) はプレゼンテーションの開封や変更を制限できます。同一ファイルで両方を使用できます。

**特定のスライドだけの編集を制限し、他のスライドに影響を与えないようにできますか？**

はい。選択したスライドの図形のみロックを適用します。これにより、他のスライドのロック設定は変更されません。

**グループ内の個々の図形にロックを適用するにはどうすればよいですか？**

グループの [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) メソッドが返すコレクションを反復処理し、各子図形に適切なロックを適用します。入れ子になったグループでも同様に繰り返します。上記の例はスライドのシェイプコレクションのみを処理しているため、個々のグループメンバーにはロックを設定していません。