---
title: JavaScript を使用してプレゼンテーションの ActiveX コントロールを管理する
linktitle: ActiveX
type: docs
weight: 80
url: /ja/nodejs-java/activex/
keywords:
- ActiveX
- ActiveX コントロール
- ActiveX の管理
- ActiveX の追加
- ActiveX の変更
- メディアプレーヤー
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint プレゼンテーション内の ActiveX テキストボックスやボタンを編集し、コントロールのプレビューを更新し、Windows Media Player コントロールを再利用します。"
---
## **イントロダクション**

ActiveX コントロールは、テキスト ボックス、コマンド ボタン、メディア プレーヤーなどのインタラクティブ要素を PowerPoint スライドに提供します。Aspose.Slides for Node.js via Java は、[BaseSlide.getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getControls) を通じてスライドのコントロールを公開します。このコレクションを使用してコントロールを編集したり、スライド上で移動したり、削除したりできます。

## **ActiveX コントロールとその保存されているプロパティの一覧**

不慣れなテンプレートを調査するには、読み取りモードで開き、各スライドのコントロールを反復処理します。この例では、スライド番号、コントロール名、[getClassId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getClassId)、および [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) で取得したすべてのキー‑バリュー ペアを報告します。プレゼンテーションは、コントロールをアクティブ化したり、イベントやマクロを呼び出したり、値を変更したり、ファイルを保存したりせずに読み取ります。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ActiveX.pptm");
try {
    const slideList = presentation.getSlides();
    for (let i = 0; i < slideList.size(); i++) {
        const controls = slideList.get_Item(i).getControls();
        for (let j = 0; j < controls.size(); j++) {
            const control = controls.get_Item(j);
            console.log(`Slide ${i + 1} | ${control.getName()} | ${control.getClassId()}`);
            const properties = control.getProperties();
            if (properties == null) {
                console.log("  Properties unavailable");
                continue;
            }
            if (properties.getCount() === 0) {
                console.log("  []");
            }
            const names = properties.getNamesOfProperties().iterator();
            while (names.hasNext()) {
                const name = names.next();
                console.log(`  ${name} = ${properties.get_Item(name)}`);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Selected output from `ActiveX.pptm` shows a text box and a command button.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

空のプロパティ コレクションは `[]` として表示されます。バイナリ ストレージを使用するコントロールの場合、[getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) は `null` を返すことがあり、`Properties unavailable` と表示されます。名前だけが必要な場合は、`null` チェックの後で [getNamesOfProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) を使用してください。レポートにはプレゼンテーションから取得できるプロパティが一覧表示されます。コントロールは実行時に追加のプロパティをサポートすることがあります。

## **ActiveX コントロールの変更**

この例は、最初のスライドに `TextBox1` という名前のテキスト ボックスと `CommandButton1` という名前のコマンド ボタンが含まれるマクロ有効プレゼンテーションを想定しています。[control properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) を使用してテキスト ボックスの値とボタンのキャプションを変更します。各コントロールには、アクティブ化前に PowerPoint が表示できる静的プレビューが用意されています。更新されたテキストと外観を示す PNG を各コントロールに提供し、[Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getSubstitutePictureFormat) を通じてこれらの画像を割り当てます。

例では、[Control.setFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#setFrame) を使用して最初のスライド上のすべてのコントロールのフレームを 100 ポイント下に移動させます。編集後のプレゼンテーションを PPTM 形式で保存し、続いて [ControlCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/#clear) を使用してそのスライドからすべての ActiveX コントロールを除去した 2 番目のコピーを保存します。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function addPreview(presentation, path) {
    const image = slides.Images.fromFile(path);
    try {
        return presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
}

function editControls() {
    const presentation = new slides.Presentation("ActiveX.pptm");
    try {
        const controls = presentation.getSlides().get_Item(0).getControls();
        let textBox;
        let button;
        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            if (control.getName() === "TextBox1") {
                textBox = control;
            } else if (control.getName() === "CommandButton1") {
                button = control;
            }
        }
        if (!textBox || !button || textBox.getProperties() == null || button.getProperties() == null) {
            console.log("The first slide must contain both named controls with editable properties.");
            return;
        }

        const textBoxPreview = addPreview(presentation, "text-box-preview.png");
        const buttonPreview = addPreview(presentation, "button-preview.png");
        textBox.getProperties().set_Item("Value", "Changed text");
        button.getProperties().set_Item("Caption", "Show message");
        textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
        button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            const frame = control.getFrame();
            const flipH = java.newByte(frame.getFlipH());
            const flipV = java.newByte(frame.getFlipV());
            const moved = new slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), flipH, flipV, frame.getRotation());
            control.setFrame(moved);
        }
        presentation.save("edited-controls.pptm", slides.SaveFormat.Pptm);

        controls.clear();
        presentation.save("removed-controls.pptm", slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}

editControls();
```

## **ActiveX メディア プレーヤー コントロールの追加**

設定済みの Windows Media Player コントロールを再利用するには、最初のスライドに `WindowsMediaPlayer1` という名前のプレーヤーが含まれるテンプレートから開始します。[SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone) はスライド全体を新しいプレゼンテーションにコピーします。例では、プレーヤーの `URL` をその [properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) に設定し、クローンされたスライドを出力の唯一のスライドとして保存します。ビデオは外部に残るため、再生中にプレーヤーがアクセスできるパスを選択してください。

```javascript
const slides = require("aspose.slides.via.java");

function addMediaPlayer() {
    const template = new slides.Presentation("template.pptx");
    try {
        const presentation = new slides.Presentation();
        try {
            const templateSlide = template.getSlides().get_Item(0);
            const slide = presentation.getSlides().addClone(templateSlide);
            const controls = slide.getControls();
            let player;
            for (let i = 0; i < controls.size(); i++) {
                const control = controls.get_Item(i);
                if (control.getName() === "WindowsMediaPlayer1") {
                    player = control;
                    break;
                }
            }
            if (!player || player.getProperties() == null) {
                console.log("The template slide must contain a named media player with editable properties.");
                return;
            }
            player.getProperties().set_Item("URL", "Wildlife.mp4");
            
            presentation.getSlides().removeAt(0);
            presentation.save("linked-video.pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        template.dispose();
    }
}

addMediaPlayer();
```

## **FAQ**

**Aspose.Slides は ActiveX コントロールを実行せずに保持できますか？**

はい。Aspose.Slides はコントロールおよびそのプロパティや位置情報をアクティブ化せずに読み取りおよび保存できます。

**ActiveX コントロールは OLE オブジェクトとどう違いますか？**

ActiveX コントロールは、テキスト入力やボタンのクリックなど、ユーザーがスライドと直接対話できるようにします。[OLE object](/slides/ja/nodejs-java/manage-ole/) は、スライドが別のアプリケーションで管理されているコンテンツ（例: Excel ワークシート）を含むかリンクすることを可能にします。

**Aspose.Slides でプレゼンテーションを保存した後、ActiveX イベントは VBA マクロを引き続きトリガーしますか？**

プレゼンテーションを PPTM などのマクロ有効形式で保存すれば、VBA プロジェクトが保持されます。Windows 用 PowerPoint のセキュリティ設定で ActiveX コントロールとマクロの両方が許可されていれば、既存のイベント ハンドラは実行されます。