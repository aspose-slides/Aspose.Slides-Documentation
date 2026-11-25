---
title: PHP でシェイプ ロックを使用してプレゼンテーションの編集を制限する
linktitle: プレゼンテーションの編集を制限
type: docs
weight: 60
url: /ja/php-java/applying-protection-to-presentation/
keywords:
- 編集の防止
- 編集からの保護
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
description: "Aspose.Slides for PHP via Java を使用して PPTX プレゼンテーションのシェイプをロック・アンロックし、選択、移動、サイズ変更、グループ化を制限する方法を学びます。"
---
## **概要**

Aspose.Slides for PHP via Java の一般的な使用例は、自動化されたワークフローの一環として PowerPoint (PPTX) プレゼンテーションを作成、更新、保存することです。ユーザーがこれらのプレゼンテーションを受け取る際に、形状の変更を制限することで、意図されたレイアウトやコンテンツを保護できます。

本記事では、スライド上で形状がどのように構成されているか、そして PPTX プレゼンテーションで形状ロックを適用および解除する方法を説明します。これらのロックを使用すると、個々の形状に対する特定の編集操作を制限できます。

## **スライドの構成**

プレゼンテーションのスライドは、オートシェイプ、テーブル、OLE オブジェクト、グループ化された形状、画像フレーム、ビデオフレーム、コネクタ、その他の要素などで構成されます。Aspose.Slides for PHP via Java では、スライド上の各要素は[Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/)クラスを継承したオブジェクトとして表現されます。

形状の種類によってロックできるオプションが異なります。[BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/)クラスは形状ロックの基底クラスです。Aspose.Slides for PHP via Java は以下のロッククラスを提供します：

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/)はオートシェイプをロックします。  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/)はコネクタ形状をロックします。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/)はグラフィカルオブジェクトをロックします。  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/)はグループ形状をロックします。  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/)は画像フレームをロックします。  

[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)全体にロックを適用するには、スライドを順に処理し、各サポート対象の形状に適切なロックを設定します。

## **保護の適用と削除**

互換性のあるプレゼンテーション エディタは形状ロックを使用して個別の編集操作を制限します。ファイルの暗号化やドキュメントレベルの書き込み保護は、別の[presentation protection settings](/slides/ja/php-java/password-protected-presentation/)です。

### **PPTX 形状への保護の適用**

Aspose.Slides for PHP via Java はスライド上の形状を操作するために[Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/)クラスを提供します。

この例では、オートシェイプに対して `true` を指定して[setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked)、[setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked)、[setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) を呼び出し、グループ形状、コネクタ、画像フレームにも同等のロックを設定します。コネクタは移動に[setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) を使用し、グループは[setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) を使用してグループ化を制限します。

この例は既存の PPTX プレゼンテーションを読み込み、各スライドのシェイプコレクション内の形状をチェックし、これらの制限を適用したコピーを保存します。扱われる 4 つのタイプ以外の形状は変更されません。ループはグループ内の子シェイプは走査しません。

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

形状ロックを解除するには、その値を `false` に設定します。以下の例では、ロックされた形状を含むプレゼンテーションを読み込み、[AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/)、[GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/)、[ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/)、[PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) を使用して選択、移動、サイズ変更の制限をクリアします。また、[GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) に `false` を渡すことでグループ化の制限も解除し、プレゼンテーションのコピーを保存します。その他のロック設定は変更されません。

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

作業ディレクトリに `photo.jpg` という名前の写真を置きます。例では左側を 12%、右側を 8% クロップし、画像フレームのロックに対して[setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked) を呼び出します。`true` を渡すことで、以降のクロップが制限され、既存のクロップが保持されます。

`PictureLocked.pptx` はクロップロックを `true` として保存します。PowerPoint では、写真が選択されていると **Crop** コマンドが無効になります。

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

### **図表をグループ化したまま保持**

この例では矩形と矢印をグループ化し、グループのロックに対して[setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) を呼び出して図の構成要素を一緒に保ちます。グループの移動や構成要素の塗りの変更など、その他の編集は引き続き可能です。

`DiagramLocked.pptx` はアン

グループ解除ロックを `true` として保存します。PowerPoint では、図全体が選択されていると **Ungroup** コマンドが無効になります。

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

### **既存の形状ロックのレポート**

テンプレートを確認するには、開いて各形状のロックオブジェクトを取得します。[getNoLocks](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/#getNoLocks) メソッドは、オブジェクト上のすべてのフラグが無効な場合に `true`、少なくとも1つが有効な場合に `false` を返します。グループとその子は別々のロックオブジェクトを持つため、グループにロックがなくても子を検査します。

この例では、オートシェイプ、画像フレーム、グループの移動をチェックします。また、画像のクロップとグループのアン

レポートは認識した有効なフラグを一覧表示し、検査しない形状タイプにはマークを付けます。

```php
use aspose\slides\Presentation;

function reportShapeLocks($shapes, $slideNumber, $prefix = "") {
    foreach ($shapes->toArray() as $shape) {
        $path = $prefix . java_values($shape->getName());
        $type = java_values($shape->getClass()->getSimpleName());
        $label = "Slide $slideNumber | $path | $type";
        $flags = [];
        $isGroup = java_instanceof($shape, java("com.aspose.slides.IGroupShape"));

        if ($isGroup) {
            $lock = $shape->getGroupShapeLock();
            if (java_values($lock->getUngroupingLocked())) {
                $flags[] = "UngroupingLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IPictureFrame"))) {
            $lock = $shape->getPictureFrameLock();
            if (java_values($lock->getCropLocked())) {
                $flags[] = "CropLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IAutoShape"))) {
            $lock = $shape->getAutoShapeLock();
        } else {
            echo "$label | Uninspected", PHP_EOL;
            continue;
        }

        if (java_values($lock->getPositionLocked())) {
            $flags[] = "PositionLocked";
        }
        if (!java_values($lock->getNoLocks())) {
            $restrictions = $flags ? implode(", ", $flags) : "Active flag not identified";
            echo "$label | $restrictions", PHP_EOL;
        }

        if ($isGroup) {
            reportShapeLocks($shape->getShapes(), $slideNumber, $path . "/");
        }
    }
}

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        reportShapeLocks($slide->getShapes(), java_values($slide->getSlideNumber()));
    }
} finally {
    $presentation->dispose();
}
```

`Sample.pptx` のスライド 1 には、アン

レポートは `Free` をスキップし、次の 2 行を出力します：

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

レポートは保存された形状レベルの編集フラグを読み取りますが、変更したりプレゼンテーションを保存したりはしません。ドキュメントレベルの書き込み保護は別の設定であり、各フラグの適用はエディタに依存します。

## **結論**

Aspose.Slides for PHP via Java を使用すると、個々の形状に対して特定の編集操作を制限したり、スライド全体に同じ制限を適用したりできます。各形状タイプがサポートするロックを選択し、制限を解除したい場合は値を `false` に設定します。

## **よくある質問**

**同じプレゼンテーションで形状ロックとパスワード保護を組み合わせることはできますか？**

はい。形状ロックは特定の編集操作を制限し、[password protection](/slides/ja/php-java/password-protected-presentation/) はプレゼンテーションの開封や変更を制限できます。両方を同じファイルで併用できます。

**特定のスライドだけの編集制限を、他のスライドに影響させずに行えますか？**

はい。対象のスライド上の形状にのみロックを適用すれば、他のスライドのロック設定は変更されません。

**グループ内の個々の形状にロックを適用するにはどうすればよいですか？**

グループの[getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) メソッドが返すコレクションを走査し、各子形状に適切なロックを適用します。入れ子になったグループがある場合も同様に、レポート例の走査方法に従って処理します。