---
title: C++ を使用したプレゼンテーションでの ActiveX コントロールの管理
linktitle: ActiveX
type: docs
weight: 80
url: /ja/cpp/activex/
keywords:
- ActiveX
- ActiveX コントロール
- ActiveX の管理
- ActiveX の追加
- ActiveX の変更
- メディア プレーヤー
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint プレゼンテーション内の ActiveX テキスト ボックスやボタンを編集し、コントロールのプレビューを更新し、Windows Media Player コントロールを再利用します。"
---
## **導入**

ActiveX コントロールは、テキストボックス、コマンド ボタン、メディア プレーヤーなどのインタラクティブ要素を PowerPoint スライドに提供します。Aspose.Slides for C++ はスライドのコントロールを [IBaseSlide::get_Controls](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_controls/) で公開します。このコレクションを使用してコントロールを編集したり、スライド上で移動したり、削除したりできます。

## **ActiveX コントロールとその保存プロパティの一覧**

慣れないテンプレートを調査するには、読み取りモードで開き、各スライド上のコントロールを列挙します。このサンプルはスライド番号、コントロール名、[クラス ID](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_classid/)、および [保存プロパティ](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_properties/) の各キーと値を報告します。プレゼンテーションはコントロールをアクティブ化したり、イベントやマクロを呼び出したり、値を変更したり、ファイルを保存したりせずに読み取ります。

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/guid.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"ActiveX.pptm");

for (auto i = 0; i < presentation->get_Slides()->get_Count(); ++i)
{
    auto controls = presentation->get_Slide(i)->get_Controls();
    for (auto j = 0; j < controls->get_Count(); ++j)
    {
        auto control = controls->idx_get(j);
        Console::WriteLine(u"Slide {0} | {1} | {2}", i + 1, control->get_Name(), control->get_ClassId().ToString());
        auto properties = control->get_Properties();
        if (!properties)
        {
            Console::WriteLine(u"  Properties unavailable");
            continue;
        }

        if (properties->get_Count() == 0)
            Console::WriteLine(u"  []");

        auto entries = properties->GetEnumerator();
        while (entries->MoveNext())
        {
            auto property = entries->get_Current();
            Console::WriteLine(u"  {0} = {1}", property.get_Key(), property.get_Value());
        }
    }
}
```

`ActiveX.pptm` から選択された出力例は、テキスト ボックスとコマンド ボタンを示します。

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

空のプロパティ コレクションは `[]` と表示されます。バイナリ ストレージを使用するコントロールの場合、`get_Properties` は `nullptr` を返すことがあり、`Properties unavailable` と表示されます。名前だけが必要な場合は、コレクションが存在することを確認した上で [get_NamesOfProperties](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/get_namesofproperties/) を使用してください。レポートはプレゼンテーションから取得できるプロパティを一覧表示します。コントロールは実行時に追加のプロパティをサポートすることがあります。

## **ActiveX コントロールの変更**

このサンプルは、最初のスライドに `TextBox1` という名前のテキスト ボックスと `CommandButton1` という名前のコマンド ボタンがあるマクロ有効プレゼンテーションを想定しています。[コントロール プロパティ コレクション](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) を使用してテキスト ボックスの値とボタンのキャプションを変更します。各コントロールには、アクティブ化前に PowerPoint が表示できる静的プレビューがあり、更新されたテキストと外観を示す PNG を用意してください。サンプルはこれらの画像を [IControl::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_substitutepictureformat/) を通じて割り当てます。

サンプルは最初のスライド上のすべてのコントロールを [frame](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/set_frame/) を変更して 100 ポイント下に移動させます。編集されたプレゼンテーションを PPTM 形式で保存し、続いて [IControlCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolcollection/clear/) を使用してそのスライドからすべての ActiveX コントロールを除去した 2 番目のコピーを保存します。

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"ActiveX.pptm");
auto controls = presentation->get_Slide(0)->get_Controls();
SharedPtr<IControl> textBox;
SharedPtr<IControl> button;
for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    if (control->get_Name() == u"TextBox1")
        textBox = control;
    else if (control->get_Name() == u"CommandButton1")
        button = control;
}

if (!textBox || !button || !textBox->get_Properties() || !button->get_Properties())
{
    Console::WriteLine(u"The first slide must contain both named controls with editable properties.");
    return;
}

if (!File::Exists(u"text-box-preview.png") || !File::Exists(u"button-preview.png"))
{
    Console::WriteLine(u"Supply both preview images before updating the controls.");
    return;
}

textBox->get_Properties()->idx_set(u"Value", u"Changed text");
button->get_Properties()->idx_set(u"Caption", u"Show message");

auto textBoxBytes = File::ReadAllBytes(u"text-box-preview.png");
auto buttonBytes = File::ReadAllBytes(u"button-preview.png");
auto textBoxPreview = presentation->get_Images()->AddImage(textBoxBytes);
auto buttonPreview = presentation->get_Images()->AddImage(buttonBytes);
textBox->get_SubstitutePictureFormat()->get_Picture()->set_Image(textBoxPreview);
button->get_SubstitutePictureFormat()->get_Picture()->set_Image(buttonPreview);

for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    auto frame = control->get_Frame();
    auto movedFrame = MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation());
    control->set_Frame(movedFrame);
}

presentation->Save(u"edited-controls.pptm", SaveFormat::Pptm);

controls->Clear();
presentation->Save(u"removed-controls.pptm", SaveFormat::Pptm);
```

## **ActiveX メディアプレーヤー コントロールの追加**

設定済みの Windows Media Player コントロールを再利用するには、最初のスライドに `WindowsMediaPlayer1` というプレーヤーが含まれるテンプレートから開始します。[ISlideCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/addclone/) はスライド全体を新しいプレゼンテーションにコピーします。サンプルはプレーヤーの `URL` を [プロパティ コレクション](https://reference.aspose.com/slides/cpp/aspose.slides/icontrolpropertiescollection/) で設定し、クローンされたスライドを出力の唯一のスライドとして保存します。動画は外部ファイルのままなので、再生時にプレーヤーがアクセスできるパスを指定してください。

```cpp
#include <DOM/IControl.h>
#include <DOM/IControlCollection.h>
#include <DOM/IControlPropertiesCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto source = MakeObject<Presentation>(u"template.pptx");
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slides()->AddClone(source->get_Slide(0));
auto controls = slide->get_Controls();

SharedPtr<IControl> player;
for (auto i = 0; i < controls->get_Count(); ++i)
{
    auto control = controls->idx_get(i);
    if (control->get_Name() == u"WindowsMediaPlayer1")
    {
        player = control;
        break;
    }
}

if (!player || !player->get_Properties())
{
    Console::WriteLine(u"The template slide must contain a named media player with editable properties.");
    return;
}

player->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

presentation->get_Slides()->RemoveAt(0);
presentation->Save(u"linked-video.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Aspose.Slides は ActiveX コントロールを実行せずに保持できますか？**

はい。Aspose.Slides はコントロールとそのプロパティおよび位置情報をアクティブ化せずに読み取り・保存できます。

**ActiveX コントロールは OLE オブジェクトとどう違いますか？**

ActiveX コントロールはユーザーがテキストを入力したりボタンをクリックしたりするなど、スライドと直接対話できるようにします。[OLE オブジェクト](/slides/ja/cpp/manage-ole/) は、スライドが別のアプリケーションで管理されているコンテンツ（例: Excel ワークシート）を含むかリンクすることを可能にします。

**Aspose.Slides でプレゼンテーションを保存した後、ActiveX イベントは VBA マクロをトリガーしますか？**

プレゼンテーションを PPTM などのマクロ対応形式で保存すれば、VBA プロジェクトが保持されます。Windows 用 PowerPoint のセキュリティ設定で ActiveX コントロールとマクロの両方が許可されていれば、既存のイベントハンドラが実行されます。