---
title: OLEの管理
type: docs
weight: 40
url: /php-java/manage-ole/
keywords:
- OLEの追加
- OLEの埋め込み
- オブジェクトの追加
- オブジェクトの埋め込み
- ファイルの埋め込み
- リンクされたオブジェクト
- オブジェクトリンクおよび埋め込み
- OLEオブジェクト
- PowerPoint 
- プレゼンテーション
- PHP
- Java
- Aspose.Slides for PHP via Java
description: PHPでPowerPointプレゼンテーションにOLEオブジェクトを追加する
---

{{% alert color="primary" %}} 

OLE（オブジェクトリンクおよび埋め込み）は、Microsoftの技術であり、1つのアプリケーションで作成されたデータやオブジェクトをリンクまたは埋め込むことで別のアプリケーションに配置できるようにします。 

{{% /alert %}} 

MS Excelで作成されたチャートを考えてみてください。このチャートはPowerPointスライド内に配置されます。そのExcelチャートはOLEオブジェクトと見なされます。

- OLEオブジェクトはアイコンとして表示される場合があります。この場合、アイコンをダブルクリックすると、チャートが関連付けられたアプリケーション（Excel）で開かれるか、オブジェクトの開くまたは編集するアプリケーションを選択するように求められます。
- OLEオブジェクトは実際の内容を表示する場合があります。たとえば、チャートの内容です。この場合、チャートはPowerPointでアクティブになり、チャートインターフェイスが読み込まれ、PowerPointアプリ内でチャートデータを修正できます。

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/)を使用すると、OLEオブジェクトフレーム（[OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame)）としてスライドにOLEオブジェクトを挿入できます。

## **スライドにOLEオブジェクトフレームを追加する**
Microsoft Excelでチャートを作成し、そのチャートをOLEオブジェクトフレームとしてスライドに埋め込む場合は、次のようにします。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. Excelチャートオブジェクトを含むExcelファイルを開き、`MemoryStream`に保存します。
1. OLEオブジェクトに関するバイト配列とその他の情報を含むスライドに[OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame)を追加します。
1. 修正したプレゼンテーションをPPTXファイルとして書き込みます。

以下の例では、ExcelファイルからチャートをOLEオブジェクトフレームとしてスライドに追加しました。
**注意**として、[IOleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IOleEmbeddedDataInfo)コンストラクタは、埋め込むオブジェクト拡張子を2番目のパラメータとして取ります。この拡張子により、PowerPointはファイルタイプを正しく解釈し、このOLEオブジェクトを開くための正しいアプリケーションを選択します。

```php
  # PPTXファイルを表すPresentationクラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセスします
    $sld = $pres->getSlides()->get_Item(0);
    # ストリームにExcelファイルをロードします
    $fs = new Java("java.io.FileInputStream", "book1.xlsx");
    $Array = new java_class("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $mstream = new Java("java.io.ByteArrayOutputStream");
    $buf = $Array->newInstance($Byte, 4096);
    while (true) {
      $bytesRead = $fs->read($buf, 0, $Array->getLength($buf));
      if ($bytesRead <= 0) {
        break;
      }
      $mstream->write($buf, 0, $bytesRead);
    } 
    $fs->close();
    # 埋め込み用のデータオブジェクトを作成します
    $dataInfo = new OleEmbeddedDataInfo($mstream->toByteArray(), "xlsx");
    $mstream->close();
    # Ole Object Frameのシェイプを追加します
    $oleObjectFrame = $sld->getShapes()->addOleObjectFrame(0, 0, $pres->getSlideSize()->getSize()->getWidth(), $pres->getSlideSize()->getSize()->getHeight(), $dataInfo);
    # PPTXファイルをディスクに保存します
    $pres->save("OleEmbed_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **OLEオブジェクトフレームにアクセスする**
OLEオブジェクトがすでにスライドに埋め込まれている場合、そのオブジェクトを次の方法で簡単に見つけたりアクセスしたりすることができます。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. OLEオブジェクトフレームシェイプにアクセスします。

   私たちの例では、最初のスライドに1つの形状だけを持つ以前に作成したPPTXを使用しました。次に、そのオブジェクトを[OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame)として*キャスト*しました。これがアクセスするために望ましいOLEオブジェクトフレームでした。
1. OLEオブジェクトフレームにアクセスすると、その上で任意の操作を行うことができます。

以下の例では、OLEオブジェクトフレーム（スライドに埋め込まれたExcelチャートオブジェクト）にアクセスし、そのファイルデータがExcelファイルに書き込まれます。

```php
  # PPTXをPresentationオブジェクトに読み込みます
  $pres = new Presentation("AccessingOLEObjectFrame.pptx");
  try {
    # 最初のスライドにアクセスします
    $sld = $pres->getSlides()->get_Item(0);
    # シェイプをOleObjectFrameとしてキャストします
    $oleObjectFrame = $sld->getShapes()->get_Item(0);
    # OLEオブジェクトを読み取り、ディスクに書き込みます
    if (!java_is_null($oleObjectFrame)) {
      # 埋め込みファイルデータを取得します
      $data = $oleObjectFrame->getEmbeddedData()->getEmbeddedFileData();
      # 埋め込みファイル拡張子を取得します
      $fileExtention = $oleObjectFrame->getEmbeddedData()->getEmbeddedFileExtension();
      # 抽出したファイルを保存するためのパスを作成します
      $extractedPath = "excelFromOLE_out" . $fileExtention;
      # 抽出したデータを保存します
      $fstr = new Java("java.io.FileOutputStream", $extractedPath);
      $Array = new java_class("java.lang.reflect.Array");
      try {
        $fstr->write($data, 0, $Array->getLength($data));
      } finally {
        $fstr->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **OLEオブジェクトデータの変更**

すでにスライドに埋め込まれているOLEオブジェクトにアクセスし、そのデータを変更するのは簡単です。

1. 埋め込まれたOLEオブジェクトを持つプレゼンテーションを開くには、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。 
1. OLEオブジェクトフレームシェイプにアクセスします。

   私たちの例では、最初のスライドに1つの形状だけを持つ以前に作成したPPTXを使用しました。次に、そのオブジェクトを[OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/OleObjectFrame)として*キャスト*しました。これがアクセスするために望ましいOLEオブジェクトフレームでした。
1. OLEオブジェクトフレームにアクセスしたら、その上で任意の操作を行うことができます。
1. Workbookオブジェクトを作成し、OLEデータにアクセスします。
1. 必要なワークシートにアクセスし、データを修正します。
1. ストリームに更新されたWorkbookを保存します。
1. OLEオブジェクトのデータをストリームデータから変更します。

以下の例では、OLEオブジェクトフレーム（スライドに埋め込まれたExcelチャートオブジェクト）にアクセスし、そのファイルデータを変更してチャートデータを変更します。

```php
  $pres = new Presentation("ChangeOLEObjectData.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $ole = null;
    # Oleフレーム用のすべての形状を走査します
    foreach($slide->getShapes() as $shape) {
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $ole = $shape;
      }
    }
    if (!java_is_null($ole)) {
      $msln = new ByteArrayInputStream($ole->getEmbeddedData()->getEmbeddedFileData());
      try {
        # Workbookでオブジェクトデータを読み取ります
        $Wb = new Workbook($msln);
        $msout = new Java("java.io.ByteArrayOutputStream");
        try {
          # ワークブックデータを修正します
          $Wb->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
          $Wb->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
          $Wb->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
          $Wb->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);
          $so1 = new OoxmlSaveOptions(SaveFormat::XLSX);
          $Wb->save($msout, $so1);
          # Oleフレームオブジェクトデータを変更します
          $newData = new OleEmbeddedDataInfo($msout->toByteArray(), $ole->getEmbeddedData()->getEmbeddedFileExtension());
          $ole->setEmbeddedData($newData);
        } finally {
          if (!java_is_null($msout)) {
            $msout->close();
          }
        }
      } finally {
        if (!java_is_null($msln)) {
          $msln->close();
        }
      }
    }
    $pres->save("OleEdit_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## スライドに他のファイルタイプを埋め込む

Excelチャートの他にも、Aspose.Slides for PHP via Javaでは、スライドに他のタイプのファイルを埋め込むことができます。たとえば、HTML、PDF、ZIPファイルをオブジェクトとしてスライドに挿入できます。ユーザーが挿入されたオブジェクトをダブルクリックすると、そのオブジェクトは自動的に関連するプログラムで起動されるか、ユーザーがオブジェクトを開くための適切なプログラムを選択するように指示されます。

このPHPコードは、HTMLとZIPをスライドに埋め込む方法を示しています：

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "embedOle.html"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $htmlBytes = $bytes;

    $dataInfoHtml = new OleEmbeddedDataInfo($htmlBytes, "html");
    $oleFrameHtml = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $dataInfoHtml);
    $oleFrameHtml->setObjectIcon(true);
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "embedOle.zip"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $zipBytes = $bytes;

    $dataInfoZip = new OleEmbeddedDataInfo($zipBytes, "zip");
    $oleFrameZip = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $dataInfoZip);
    $oleFrameZip->setObjectIcon(true);
    $pres->save("embeddedOle.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## 埋め込まれたオブジェクトのファイルタイプを設定する

プレゼンテーションを作成する際、古いOLEオブジェクトを新しいものと置き換える必要がある場合や、サポートされていないOLEオブジェクトをサポートされているものと置き換える必要がある場合があります。

Aspose.Slides for PHP via Javaを使用すると、埋め込まれたオブジェクトのファイルタイプを設定できます。この方法でOLEフレームデータやその拡張子を変更できます。

以下は、埋め込まれたOLEオブジェクトのファイルタイプを設定する方法を示します。

```php
  $pres = new Presentation("embeddedOle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $oleObjectFrame = $slide->getShapes()->get_Item(0);
    echo("現在の埋め込みデータ拡張子は: " . $oleObjectFrame->getEmbeddedData()->getEmbeddedFileExtension());
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "embedOle.zip"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $oleObjectFrame->setEmbeddedData(new OleEmbeddedDataInfo($bytes, "zip"));

    $pres->save("embeddedChanged.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## 埋め込まれたオブジェクトのアイコン画像とタイトルを設定する

OLEオブジェクトを埋め込むと、アイコン画像とタイトルからなるプレビューが自動的に追加されます。プレビューは、ユーザーがOLEオブジェクトにアクセスまたは開く前に見る内容です。

プレビュー内の要素として特定の画像とテキストを使用したい場合、Aspose.Slides for PHP via Javaを使用してアイコン画像とタイトルを設定できます。

このPHPコードは、埋め込まれたオブジェクトのアイコン画像とタイトルを設定する方法を示しています：

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $oleObjectFrame = $slide->getShapes()->get_Item(0);
    $oleImage;
    $image = Images->fromFile("image.png");
    try {
      $oleImage = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $oleObjectFrame->setSubstitutePictureTitle("私のタイトル");
    $oleObjectFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
    $oleObjectFrame->setObjectIcon(false);
    $pres->save("embeddedOle-newImage.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **OLEオブジェクトフレームのサイズ変更と位置の変更を防ぐ**

リンクされたOLEオブジェクトをプレゼンテーションスライドに追加した後、PowerPointでプレゼンテーションを開くと、リンクを更新するかどうかを尋ねるメッセージが表示されることがあります。「リンクを更新」ボタンをクリックすると、PowerPointはリンクされたOLEオブジェクトからデータを更新し、オブジェクトプレビューを更新するため、OLEオブジェクトフレームのサイズと位置が変更される場合があります。PowerPointがオブジェクトのデータを更新するよう促すことを防ぐには、[OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)クラスの`setUpdateAutomatic`メソッドを`false`に設定します。

```php
$oleObjectFrame->setUpdateAutomatic(false);
```

## 埋め込まれたファイルの抽出

Aspose.Slides for PHP via Javaを使用すると、OLEオブジェクトとしてスライドに埋め込まれたファイルを次の方法で抽出できます。

1. 抽出するOLEオブジェクトを含む[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
2. プレゼンテーション内のすべてのシェイプをループして[OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe)シェイプにアクセスします。
3. OLEオブジェクトフレームから埋め込まれたファイルのデータにアクセスし、ディスクに書き込みます。 

このPHPコードは、OLEオブジェクトとしてスライドに埋め込まれたファイルを抽出する方法を示します：

```php
  $pres = new Presentation("embeddedOle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    for($index = 0; $index < java_values($slide->getShapes()->size()) ; $index++) {
      $shape = $slide->getShapes()->get_Item($index);
      $oleFrame = $shape;
      if (!java_is_null($oleFrame)) {
        $data = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $extension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
        # 抽出したデータを保存します
        $fstr = new Java("java.io.FileOutputStream", "oleFrame" . $index . $extension);
        $Array = new java_class("java.lang.reflect.Array");
        try {
          $fstr->write($data, 0, $Array->getLength($data));
        } finally {
          $fstr->close();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```