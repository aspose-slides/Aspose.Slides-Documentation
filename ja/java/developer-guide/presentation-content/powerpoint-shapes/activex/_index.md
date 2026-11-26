---
title: Java でプレゼンテーションの ActiveX コントロールを管理する
linktitle: ActiveX
type: docs
weight: 80
url: /ja/java/activex/
keywords:
- ActiveX
- ActiveX コントロール
- ActiveX の管理
- ActiveX の追加
- ActiveX の変更
- メディア プレーヤー
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint プレゼンテーション内の ActiveX テキストボックスとボタンを編集し、コントロールのプレビューを更新し、Windows Media Player コントロールを再利用します。"
---
## **導入**

ActiveX コントロールは、テキスト ボックス、コマンド ボタン、メディア プレーヤーなどのインタラクティブ要素を PowerPoint スライドに提供します。Aspose.Slides for Java は、スライドのコントロールを [IBaseSlide.getControls](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getControls--) を介して公開します。このコレクションを使用してコントロールを編集したり、スライド上で移動したり、削除したりします。

## **ActiveX コントロールとその格納プロパティの一覧**

不慣れなテンプレートを調査するには、読み取りモードで開き、各スライド上のコントロールを反復処理します。この例は、スライド番号、コントロール名、[getClassId](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getClassId--)、および [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--) の各キー・バリュー ペアを報告します。コントロールをアクティブ化したり、イベントやマクロを呼び出したり、値を変更したり、ファイルを保存したりせずにプレゼンテーションを読み取ります。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    for (int i = 0; i < presentation.getSlides().size(); i++) {
        for (IControl control : presentation.getSlides().get_Item(i).getControls()) {
            System.out.printf("Slide %d | %s | %s%n", i + 1, control.getName(), control.getClassId());
            IControlPropertiesCollection properties = control.getProperties();
            if (properties == null) {
                System.out.println("  Properties unavailable");
                continue;
            }
            if (properties.getCount() == 0) {
                System.out.println("  []");
            }
            for (String name : properties.getNamesOfProperties()) {
                System.out.printf("  %s = %s%n", name, properties.get_Item(name));
            }
        }
    }
} finally {
    presentation.dispose();
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

空のプロパティ コレクションは `[]` として表示されます。バイナリ ストレージを使用するコントロールの場合、[getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--) は `null` を返すことがあり、`Properties unavailable` と表示されます。名前だけが必要な場合は、null チェック後に [getNamesOfProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--) を使用します。レポートはプレゼンテーションから取得可能なプロパティを一覧表示します。コントロールは実行時に追加のプロパティをサポートすることがあります。

## **ActiveX コントロールの変更**

この例は、最初のスライドに `TextBox1` という名前のテキスト ボックスと `CommandButton1` という名前のコマンド ボタンがあるマクロ対応プレゼンテーションを前提としています。テキスト ボックスの値とボタンのキャプションを変更するために、[control properties collection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) を使用します。各コントロールには、アクティブ化前に PowerPoint が表示できる静的プレビューもあります。更新されたテキストと外観を示す PNG を各コントロールに提供してください。例ではこれらの画像を [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getSubstitutePictureFormat--) を介して割り当てています。

例では、[IControl.setFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-) を使用して最初のスライド上のすべてのコントロールのフレームを下方向に 100 ポイント移動させます。編集されたプレゼンテーションを PPTM 形式で保存した後、[IControlCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/#clear--) を使用して、そのスライドからすべての ActiveX コントロールを除去した 2 番目のコピーを保存します。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    IControlCollection controls = presentation.getSlides().get_Item(0).getControls();
    IControl textBox = null;
    IControl button = null;
    for (IControl control : controls) {
        if ("TextBox1".equals(control.getName())) {
            textBox = control;
        } else if ("CommandButton1".equals(control.getName())) {
            button = control;
        }
    }
    if (textBox == null || button == null || textBox.getProperties() == null || button.getProperties() == null) {
        System.out.println("The first slide must contain both named controls with editable properties.");
        return;
    }

    Path textBoxPath = Paths.get("text-box-preview.png");
    Path buttonPath = Paths.get("button-preview.png");
    byte[] textBoxBytes = Files.readAllBytes(textBoxPath);
    byte[] buttonBytes = Files.readAllBytes(buttonPath);
    IPPImage textBoxPreview = presentation.getImages().addImage(textBoxBytes);
    IPPImage buttonPreview = presentation.getImages().addImage(buttonBytes);
    textBox.getProperties().set_Item("Value", "Changed text");
    button.getProperties().set_Item("Caption", "Show message");
    textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
    button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

    for (IControl control : controls) {
        IShapeFrame frame = control.getFrame();
        ShapeFrame moved = new ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation());
        control.setFrame(moved);
    }
    presentation.save("edited-controls.pptm", SaveFormat.Pptm);

    controls.clear();
    presentation.save("removed-controls.pptm", SaveFormat.Pptm);
} catch (IOException e) {
    System.out.println("Could not read a control preview: " + e.getMessage());
} finally {
    presentation.dispose();
}
```
## **ActiveX メディア プレーヤー コントロールの追加**

構成済みの Windows Media Player コントロールを再利用するには、最初のスライドに `WindowsMediaPlayer1` という名前のプレーヤーが含まれるテンプレートから開始します。[ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) はスライド全体を新しいプレゼンテーションにコピーします。例では、プレーヤーの `URL` をその [properties collection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) に設定し、クローンしたスライドを出力の唯一のスライドとして保存します。ビデオは外部に保持されるため、再生時にプレーヤーがアクセスできるパスを選択してください。

```java
import com.aspose.slides.*;

Presentation template = new Presentation("template.pptx");
try {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().addClone(template.getSlides().get_Item(0));
        IControl player = null;
        for (IControl control : slide.getControls()) {
            if ("WindowsMediaPlayer1".equals(control.getName())) {
                player = control;
                break;
            }
        }
        if (player == null || player.getProperties() == null) {
            System.out.println("The template slide must contain a named media player with editable properties.");
            return;
        }
        player.getProperties().set_Item("URL", "Wildlife.mp4");
        
        presentation.getSlides().removeAt(0);
        presentation.save("linked-video.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    template.dispose();
}
```
## **よくある質問**

**Aspose.Slides は ActiveX コントロールを実行せずに保持できますか？**

はい。Aspose.Slides はコントロールをアクティブ化せずに、プロパティや位置を含めて読み取りおよび保存できます。

**ActiveX コントロールは OLE オブジェクトとどのように異なりますか？**

ActiveX コントロールはユーザーがテキストを入力したりボタンをクリックしたりしてスライドと対話できるようにします。[OLE オブジェクト](/slides/ja/java/manage-ole/) は、スライドが別のアプリケーションで管理されているコンテンツ（たとえば Excel ワークシート）を含むかリンクできるようにします。

**プレゼンテーションを Aspose.Slides で保存した後、ActiveX イベントは VBA マクロを引き続きトリガーしますか？**

プレゼンテーションを PPTM などのマクロ対応形式で保存して VBA プロジェクトを保持してください。PowerPoint for Windows は、セキュリティ設定で ActiveX コントロールとマクロの両方が許可されている場合に、既存のイベントハンドラーを実行できます。