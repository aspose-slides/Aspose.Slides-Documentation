---
title: PHP を使用したプレゼンテーションでの ActiveX コントロールの管理
linktitle: ActiveX
type: docs
weight: 80
url: /ja/php-java/activex/
keywords:
- ActiveX
- ActiveX コントロール
- ActiveX の管理
- ActiveX の追加
- ActiveX の変更
- メディア プレーヤー
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint プレゼンテーション内の ActiveX テキスト ボックスやボタンを編集し、コントロールのプレビューを更新し、Windows Media Player コントロールを再利用します。"
---
## **導入**

ActiveX コントロールは、テキスト ボックス、コマンド ボタン、メディア プレーヤーなどのインタラクティブ要素を PowerPoint スライドに提供します。Aspose.Slides for PHP via Java は、スライドのコントロールを [BaseSlide::getControls](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getControls) を介して公開します。このコレクションを使用して、コントロールを編集したり、スライド上で移動したり、削除したりできます。

## **ActiveX コントロールとその保存されたプロパティの一覧**

不明なテンプレートを調査するには、読み取りモードで開き、各スライドのコントロールを反復処理します。この例は、スライド番号、コントロール名、[getClassId](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getClassId)、および [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties) の各キー-バリュー ペアを報告します。コントロールをアクティブ化したり、イベントやマクロを呼び出したり、値を変更したり、ファイルを保存したりせずにプレゼンテーションを読み取ります。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ActiveX.pptm");
try {
    $slides = $presentation->getSlides();
    for ($i = 0; $i < java_values($slides->size()); $i++) {
        $controls = $slides->get_Item($i)->getControls();
        for ($j = 0; $j < java_values($controls->size()); $j++) {
            $control = $controls->get_Item($j);
            printf("Slide %d | %s | %s\n", $i + 1, $control->getName(), $control->getClassId());
            $properties = $control->getProperties();
            if (java_is_null($properties)) {
                echo "  Properties unavailable\n";
                continue;
            }
            if (java_values($properties->getCount()) === 0) {
                echo "  []\n";
                continue;
            }
            $names = $properties->getNamesOfProperties()->iterator();
            while (java_values($names->hasNext())) {
                $name = $names->next();
                printf("  %s = %s\n", $name, $properties->get_Item($name));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

`ActiveX.pptm` の選択された出力は、テキスト ボックスとコマンド ボタンを示しています。

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

空のプロパティ コレクションは `[]` と表示されます。バイナリ ストレージを使用するコントロールの場合、[getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties) は `null` を返すことがあり、`Properties unavailable` と表示されます。名前だけが必要な場合は、null チェックの後に [getNamesOfProperties](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) を使用してください。レポートはプレゼンテーションから利用可能なプロパティを一覧表示します。コントロールは実行時に追加のプロパティをサポートする場合があります。

## **ActiveX コントロールの変更**

この例は、最初のスライドに `TextBox1` という名前のテキスト ボックスと `CommandButton1` という名前のコマンド ボタンが含まれる、マクロ有効化プレゼンテーションを前提としています。テキスト ボックスの値とボタンのキャプションを変更するために、[control properties collection](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) を使用します。各コントロールには、アクティブ化前に PowerPoint が表示できる静的プレビューもあります。更新されたテキストと外観を示す PNG を各コントロールに提供します。例では、これらの画像を [Control::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getSubstitutePictureFormat) を介して割り当てています。

この例は、[Control::setFrame](https://reference.aspose.com/slides/php-java/aspose.slides/control/#setFrame) でフレームを設定し、最初のスライド上のすべてのコントロールを 100 ポイント下に移動します。編集されたプレゼンテーションを PPTM 形式で保存し、次に [ControlCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/#clear) を使用して、同スライドからすべての ActiveX コントロールが削除された 2 番目のコピーを保存します。

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("ActiveX.pptm");
try {
    $controls = $presentation->getSlides()->get_Item(0)->getControls();
    $textBox = null;
    $button = null;
    for ($j = 0; $j < java_values($controls->size()); $j++) {
        $control = $controls->get_Item($j);
        $name = (string) $control->getName();
        if ($name === "TextBox1") {
            $textBox = $control;
        } elseif ($name === "CommandButton1") {
            $button = $control;
        }
    }
    if ($textBox === null || $button === null || java_is_null($textBox->getProperties()) || java_is_null($button->getProperties())) {
        echo "The first slide must contain both named controls with editable properties.\n";
        return;
    }

    foreach ([[$textBox, "text-box-preview.png"], [$button, "button-preview.png"]] as [$control, $path]) {
        $image = Images::fromFile($path);
        try {
            $preview = $presentation->getImages()->addImage($image);
            $control->getSubstitutePictureFormat()->getPicture()->setImage($preview);
        } finally {
            $image->dispose();
        }
    }
    $textBox->getProperties()->set_Item("Value", "Changed text");
    $button->getProperties()->set_Item("Caption", "Show message");

    for ($j = 0; $j < java_values($controls->size()); $j++) {
        $control = $controls->get_Item($j);
        $frame = $control->getFrame();
        $newY = java_values($frame->getY()) + 100;
        $moved = new ShapeFrame($frame->getX(), $newY, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation());
        $control->setFrame($moved);
    }
    $presentation->save("edited-controls.pptm", SaveFormat::Pptm);

    $controls->clear();
    $presentation->save("removed-controls.pptm", SaveFormat::Pptm);
} finally {
    $presentation->dispose();
}
```

## **ActiveX メディア プレーヤー コントロールの追加**

設定済みの Windows Media Player コントロールを再利用するには、最初のスライドに `WindowsMediaPlayer1` という名前のプレーヤーが含まれるテンプレートから開始します。[SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addClone) はスライド全体を新しいプレゼンテーションにコピーします。この例は、プレーヤーの `URL` をその [properties collection](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) に設定し、クローンされたスライドを出力の唯一のスライドとして保存します。動画は外部のままなので、再生中にプレーヤーがアクセスできるパスを選択してください。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$template = new Presentation("template.pptx");
try {
    $presentation = new Presentation();
    try {
        $slides = $presentation->getSlides();
        $sourceSlide = $template->getSlides()->get_Item(0);
        $slide = $slides->addClone($sourceSlide);
        $player = null;
        $controls = $slide->getControls();
        for ($j = 0; $j < java_values($controls->size()); $j++) {
            $control = $controls->get_Item($j);
            if ((string) $control->getName() === "WindowsMediaPlayer1") {
                $player = $control;
                break;
            }
        }
        if ($player === null || java_is_null($player->getProperties())) {
            echo "The template slide must contain a named media player with editable properties.\n";
            return;
        }
        $player->getProperties()->set_Item("URL", "Wildlife.mp4");
        $slides->removeAt(0);
        $presentation->save("linked-video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $template->dispose();
}
```

## **よくある質問**

**Aspose.Slides は、ActiveX コントロールを実行せずに保持できますか？**

はい。Aspose.Slides は、コントロールをアクティブ化せずに、そのプロパティと位置を含めて読み取りおよび保存できます。

**ActiveX コントロールは OLE オブジェクトとどのように異なりますか？**

ActiveX コントロールは、テキスト入力やボタンのクリックなど、ユーザーがスライドと対話できるようにします。[OLE オブジェクト](/slides/ja/php-java/manage-ole/) は、スライドが別のアプリケーションで管理されるコンテンツ（例: Excel ワークシート）を含むかリンクすることを可能にします。

**Aspose.Slides でプレゼンテーションを保存した後、ActiveX イベントは VBA マクロを引き続きトリガーしますか？**

プレゼンテーションを PPTM などのマクロ有効形式で保存して VBA プロジェクトを保持してください。PowerPoint for Windows は、セキュリティ設定で ActiveX コントロールとマクロの両方が許可されている場合、既存のイベント ハンドラーを実行できます。