---
title: OLEアイコンにキャプションを設定する
type: docs
weight: 110
url: /cpp/set-caption-to-ole-icon/
---

新しい **get_SubstitutePictureTitle()** と **set_SubstitutePictureTitle()** メソッドが **IOleObjectFrame** および **OleObjectFrame** クラスに追加されました。これによりOLEアイコンのキャプションを取得、設定、または変更することができます。以下のコードスニペットは、Excelオブジェクトを作成し、そのキャプションを設定するサンプルを示しています。

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// スライドにOLEオブジェクトを追加
auto allBytes = System::IO::File::ReadAllBytes(u"oleSourceFile.xlsx");
auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(allBytes, "xlsx");

auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(20, 20, 50, 50, dataInfo);
    
// プレゼンテーションの画像コレクションに画像を追加
auto image = Images::FromFile(u"oleIconFile.ico");
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// OLEオブジェクトのアイコンとして画像を設定
oleFrame->set_IsObjectIcon(true);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(ppImage);

// OLEアイコンにキャプションを設定
oleFrame->set_SubstitutePictureTitle(u"キャプションの例");
```