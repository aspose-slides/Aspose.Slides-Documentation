---
title: PHP でシェイプ ロックを使用したプレゼンテーション編集の制限
linktitle: プレゼンテーション編集の制限
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
description: "Aspose.Slides for PHP via Java を使用して PPTX プレゼンテーションのシェイプをロックおよびアンロックし、選択、移動、サイズ変更、グループ化を制限する方法を学びます。"
---
## **概要**

Aspose.Slides for PHP via Java の一般的な使用方法は、PowerPoint (PPTX) プレゼンテーションを自動化されたワークフローの一部として作成、更新、保存することです。ユーザーがこれらのプレゼンテーションを受け取る際に、シェイプへの変更を制限することで、意図したレイアウトとコンテンツを保護できます。

この記事では、スライド上でシェイプがどのように構成されているか、そして PPTX プレゼンテーションでシェイプ ロックを適用および削除する方法について説明します。これらのロックを使用すると、個々のシェイプに対する特定の編集操作を制限できます。

## **スライドの構成**

プレゼンテーション スライドは、オートシェイプ、テーブル、OLE オブジェクト、グループ シェイプ、ピクチャ フレーム、ビデオ フレーム、コネクタ、およびプレゼンテーションの作成に使用されるその他の要素で構成されています。Aspose.Slides for PHP via Java では、スライド上の各要素は [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) クラスを継承したオブジェクトとして表されます。

シェイプの種類に応じて異なるロック オプションが公開されます。[BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) クラスはシェイプ ロックの基底クラスです。Aspose.Slides for PHP via Java は以下のロック クラスを提供します:
- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) オートシェイプをロックします。
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) コネクタ シェイプをロックします。
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) グラフィック オブジェクトをロックします。
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) グループ シェイプをロックします。
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) ピクチャ フレームをロックします。

ロックを [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 全体に適用するには、スライドを反復処理し、サポートされている各シェイプに適切なロックを設定します。

## **保護の適用と解除**

対応するプレゼンテーション エディタはシェイプ ロックを使用して個々の編集操作を制限します。ファイル暗号化およびドキュメント レベルの書き込み保護は、別の [プレゼンテーション保護設定](/slides/ja/php-java/password-protected-presentation/) です。

### **PPTX シェイプへの保護の適用**

Aspose.Slides for PHP via Java はスライド上のシェイプを操作するための [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) クラスを提供します。

この例では、オートシェイプに対して `true` を指定して [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked)、[setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked)、[setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) を呼び出し、グループ シェイプ、コネクタ、ピクチャ フレームにも同等のロックを設定します。コネクタは移動のために [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) を使用し、グループはグループ化を制限するために [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) も使用します。

この例は既存の PPTX プレゼンテーションを読み込み、各スライドのシェイプ コレクション内のシェイプをチェックし、これらの制限が適用されたコピーを保存します。扱われる 4 種類以外のシェイプは変更されません。ループはグループ内の子シェイプを走査しません。

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

シェイプ ロックを解除するには、その値を `false` に設定します。以下の例では、シェイプ ロックが設定されたプレゼンテーションを読み込み、[AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/)、[GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/)、[ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/)、[PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) を使用して選択、移動、サイズ変更の制限をクリアします。また、[GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) に `false` を渡すことでグループ化の制限も解除し、プレゼンテーションのコピーを保存します。他のロック設定は変更されません。

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

### **画像のクロップを保持**

`photo.jpg` という名前の写真を作業ディレクトリに配置します。この例では左から 12%、右から 8% をクロップし、ピクチャ フレームのロックに対して [setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked) を呼び出します。`true` を渡すとさらにクロップできなくなり、既存のクロップが保持されます。

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $image = Images::fromFile("photo.jpg");
    try {
        $photo = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $pictureFrame = $shapes->addPictureFrame(ShapeType::Rectangle, 20, 30, 270, 160, $photo);
    $pictureFrame->getPictureFormat()->setCropLeft(12);
    $pictureFrame->getPictureFormat()->setCropRight(8);

    $pictureFrameLock = $pictureFrame->getPictureFrameLock();
    $pictureFrameLock->setAspectRatioLocked(false);
    $pictureFrameLock->setCropLocked(true);

    $presentation->save("PictureLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`PictureLocked.pptx` はクロップ ロックを `true` として保存します。PowerPoint では、写真が選択されていると **Crop** コマンドが無効になります。

### **図表をグループ化したまま保持**

この例では矩形と矢印をグループ化し、グループのロックに対して [setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) を呼び出して図表のコンポーネントをまとめたままにします。グループの移動やコンポーネントの塗りつぶしの変更など、他の編集は引き続き可能です。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $groupShape = $shapes->addGroupShape();
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 70, 90, 50);
    $groupShape->getShapes()->addAutoShape(ShapeType::RightArrow, 190, 80, 60, 30);
    $groupShape->getGroupShapeLock()->setUngroupingLocked(true);

    $presentation->save("DiagramLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`DiagramLocked.pptx` はアングループ ロックを `true` として保存します。PowerPoint では、図全体が選択されていると **Ungroup** コマンドが無効になります。

### **結論**

Aspose.Slides for PHP via Java を使用すると、個々のシェイプに対して特定の編集操作を制限したり、スライド全体に同じ制限を適用したりできます。各シェイプ タイプでサポートされているロックを選択し、制限を解除する必要がある場合はその値を `false` に設定してください。

## **よくある質問**

**プレゼンテーションでシェイプ ロックとパスワード保護を同時に組み合わせることはできますか？**

はい。シェイプ ロックは特定の編集操作を制限し、[パスワード保護](/slides/ja/php-java/password-protected-presentation/) はプレゼンテーションの開封または変更を制限できます。両方を同一ファイルで使用可能です。

**特定のスライドだけの編集を制限し、他のスライドには影響させないことはできますか？**

はい。選択したスライド上のシェイプにのみロックを適用します。これにより、他のスライドのロック設定は変更されません。

**グループ内の個々のシェイプにロックを適用するにはどうすればよいですか？**

グループの [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) メソッドが返すコレクションを反復処理し、各子シェイプに適切なロックを適用します。入れ子になったグループについても同様に繰り返します。上記の例はスライドのシェイプ コレクションのみを処理しているため、個々のグループ メンバーへのロックは設定されません。