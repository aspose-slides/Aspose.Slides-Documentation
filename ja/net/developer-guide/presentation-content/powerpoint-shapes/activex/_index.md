---
title: ".NET でプレゼンテーションの ActiveX コントロールを管理する"
linktitle: "ActiveX"
type: docs
weight: 80
url: /ja/net/activex/
keywords:
- ActiveX
- ActiveX コントロール
- ActiveX の管理
- ActiveX の追加
- ActiveX の変更
- メディア プレーヤー
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint プレゼンテーションの ActiveX テキスト ボックスやボタンを編集し、コントロールのプレビューを更新し、Windows Media Player コントロールを再利用します。"
---
## **概要**

ActiveX コントロールは、テキスト ボックス、コマンド ボタン、メディア プレーヤーなどのインタラクティブ要素を PowerPoint スライドに提供します。Aspose.Slides for .NET は、スライドのコントロールを [IBaseSlide.Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/controls/) で公開します。このコレクションを使用してコントロールを編集したり、スライド上で移動したり、削除したりできます。

## **ActiveX コントロールとその保存プロパティの一覧**

不慣れなテンプレートを調査するには、読み取りモードで開き、各スライドのコントロールを反復処理します。このサンプルは、スライド番号、コントロール名、[ClassId](https://reference.aspose.com/slides/net/aspose.slides/icontrol/classid/) および [Properties](https://reference.aspose.com/slides/net/aspose.slides/icontrol/#properties) の各キー‑バリュー ペアを報告します。コントロールをアクティブ化したり、イベントやマクロを呼び出したり、値を変更したり、ファイルを保存したりせずにプレゼンテーションを読み取ります。

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("ActiveX.pptm");

for (var i = 0; i < presentation.Slides.Count; i++)
{
    foreach (var control in presentation.Slides[i].Controls)
    {
        Console.WriteLine($"Slide {i + 1} | {control.Name} | {control.ClassId}");
        var properties = control.Properties;

        if (properties == null)
        {
            Console.WriteLine("  Properties unavailable");
            continue;
        }

        if (properties.Count == 0)
            Console.WriteLine("  []");

        foreach (var property in properties)
            Console.WriteLine($"  {property.Key} = {property.Value}");
    }
}
```

`ActiveX.pptm` の選択された出力には、テキスト ボックスとコマンド ボタンが表示されます。

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

空のプロパティ コレクションは `[]` として表示されます。バイナリ ストレージを使用するコントロールの場合、`Properties` は `null` を返すことがあり、`Properties unavailable` と表示されます。名前だけが必要な場合は、`null` チェックの後で [NamesOfProperties](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/namesofproperties/) を使用してください。レポートはプレゼンテーションから取得可能なプロパティを一覧表示します。コントロールは実行時に追加のプロパティをサポートすることがあります。

## **ActiveX コントロールの変更**

このサンプルは、最初のスライドに `TextBox1` という名前のテキスト ボックスと `CommandButton1` という名前のコマンド ボタンがある、マクロ有効プレゼンテーションを想定しています。[control properties collection](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) を使用してテキスト ボックスの値とボタンのキャプションを変更します。各コントロールには、アクティブ化前に PowerPoint が表示できる静的プレビューがあります。更新されたテキストと外観を示す PNG を各コントロールに提供してください。サンプルはこれらの画像を [IControl.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/icontrol/substitutepictureformat/) で割り当てます。

サンプルは、最初のスライド上のすべてのコントロールを [Frame](https://reference.aspose.com/slides/net/aspose.slides/icontrol/frame/) を変更して 100 ポイント下方向に移動させます。編集後のプレゼンテーションを PPTM 形式で保存し、次に [IControlCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides/icontrolcollection/clear/) を使用してそのスライドからすべての ActiveX コントロールを削除したコピーを保存します。

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ActiveX.pptm");

var controls = presentation.Slides[0].Controls;
var textBox = controls.FirstOrDefault(control => control.Name == "TextBox1");
var button = controls.FirstOrDefault(control => control.Name == "CommandButton1");

if (textBox?.Properties == null || button?.Properties == null)
{
    Console.WriteLine("The first slide must contain both named controls with editable properties.");
    return;
}

if (!File.Exists("text-box-preview.png") || !File.Exists("button-preview.png"))
{
    Console.WriteLine("Supply both preview images before updating the controls.");
    return;
}

textBox.Properties["Value"] = "Changed text";
button.Properties["Caption"] = "Show message";

using var textBoxPreview = File.OpenRead("text-box-preview.png");
using var buttonPreview = File.OpenRead("button-preview.png");
textBox.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(textBoxPreview);
button.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(buttonPreview);

foreach (var control in controls)
{
    var frame = control.Frame;
    control.Frame = new ShapeFrame(frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

presentation.Save("edited-controls.pptm", SaveFormat.Pptm);

controls.Clear();
presentation.Save("removed-controls.pptm", SaveFormat.Pptm);
```
## **ActiveX メディア プレーヤー コントロールの追加**

設定済みの Windows Media Player コントロールを再利用するには、最初のスライドに `WindowsMediaPlayer1` という名前のプレーヤーが含まれるテンプレートから開始します。[ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) がスライド全体を新しいプレゼンテーションにコピーします。サンプルはプレーヤーの `URL` をその [properties collection](https://reference.aspose.com/slides/net/aspose.slides/icontrolpropertiescollection/) に設定し、クローンしたスライドを出力の唯一のスライドとして保存します。ビデオは外部のままなので、再生時にプレーヤーがアクセスできるパスを選択してください。

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var template = new Presentation("template.pptx");
using var presentation = new Presentation();

var slide = presentation.Slides.AddClone(template.Slides[0]);
var player = slide.Controls.FirstOrDefault(control => control.Name == "WindowsMediaPlayer1");

if (player?.Properties == null)
{
    Console.WriteLine("The template slide must contain a named media player with editable properties.");
    return;
}

player.Properties["URL"] = "Wildlife.mp4";

presentation.Slides.RemoveAt(0);
presentation.Save("linked-video.pptx", SaveFormat.Pptx);
```
## **FAQ**

**Aspose.Slides は、ActiveX コントロールを実行せずに保持できますか？**

はい。Aspose.Slides は、コントロールとそのプロパティおよび位置情報をアクティブ化せずに読み取り、保存できます。

**ActiveX コントロールは OLE オブジェクトとどう違いますか？**

ActiveX コントロールは、テキスト入力やボタンのクリックなど、ユーザーがスライドと対話できるようにします。[OLE オブジェクト](/slides/ja/net/manage-ole/) は、スライドが別のアプリケーションで管理されるコンテンツ（例: Excel ワークシート）を含むかリンクすることを可能にします。

**プレゼンテーションを Aspose.Slides で保存した後、ActiveX イベントは VBA マクロを引き続きトリガーしますか？**

プレゼンテーションを PPTM などのマクロ対応形式で保存すれば、VBA プロジェクトが保持されます。PowerPoint for Windows は、セキュリティ設定で ActiveX コントロールとマクロの両方が許可されている場合、既存のイベント ハンドラを実行できます。