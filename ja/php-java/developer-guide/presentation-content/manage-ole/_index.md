---
title: PHPでプレゼンテーションのOLEを管理する
linktitle: OLEを管理
type: docs
weight: 40
url: /ja/php-java/manage-ole/
keywords:
- OLEオブジェクト
- オブジェクトリンクと埋め込み
- OLEを追加
- OLEを埋め込む
- オブジェクトを追加
- オブジェクトを埋め込む
- ファイルを追加
- ファイルを埋め込む
- リンクされたオブジェクト
- リンクされたファイル
- OLEを変更
- OLEアイコン
- OLEタイトル
- OLE抽出
- オブジェクトを抽出
- ファイルを抽出
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument ファイルの OLE オブジェクト管理を最適化します。OLE コンテンツをシームレスに埋め込み、更新、エクスポートできます。"
---

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) は、1 つのアプリケーションで作成されたデータやオブジェクトを、リンクまたは埋め込みにより別のアプリケーションに配置できる Microsoft の技術です。 

{{% /alert %}} 

MS Excel で作成したチャートを考えてみてください。そのチャートを PowerPoint のスライドに配置します。この Excel のチャートは OLE オブジェクトと見なされます。 

- OLE オブジェクトはアイコンとして表示されることがあります。この場合、アイコンをダブルクリックすると、チャートは関連付けられたアプリケーション（Excel）で開かれるか、オブジェクトの開封または編集のためにアプリケーションを選択するよう求められます。 
- OLE オブジェクトは実際の内容（たとえばチャートの内容）を表示することもあります。この場合、PowerPoint 内でチャートがアクティブになり、チャートインターフェイスが読み込まれ、PowerPoint 上でチャートのデータを編集できます。 

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) を使用すると、スライドに OLE オブジェクトを OLE オブジェクトフレームとして挿入できます（[OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)）。 

## **スライドに OLE オブジェクトフレームを追加**

Microsoft Excel で既にチャートを作成し、それを OLE オブジェクトフレームとしてスライドに埋め込みたいとします。その場合は以下の手順で Aspose.Slides for PHP via Java を使用できます。 

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。 
1. インデックスを使用してスライドの参照を取得します。 
1. Excel ファイルをバイト配列として読み取ります。 
1. バイト配列や OLE オブジェクトに関するその他の情報を含めて、スライドに [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) を追加します。 
1. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。 

以下の例では、Excel ファイルからチャートを取得し、Aspose.Slides for PHP via Java を使用して OLE オブジェクトフレームとしてスライドに追加しています。  
**注**： [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) コンストラクタは第2引数に埋め込み可能なオブジェクトの拡張子を受け取ります。この拡張子により、PowerPoint はファイルタイプを正しく解釈し、この OLE オブジェクトを開く適切なアプリケーションを選択できます。  
```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// Prepare data for the OLE object.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// Add the OLE object frame to the slide.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


### **リンクされた OLE オブジェクトフレームの追加**

Aspose.Slides for PHP via Java を使用すると、データを埋め込む代わりにファイルへのリンクだけで [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) を追加できます。  

以下の PHP コードは、リンクされた Excel ファイルを使用してスライドに [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) を追加する方法を示しています：  
```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// Add an OLE object frame with a linked Excel file.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **OLE オブジェクトフレームへのアクセス**

スライドに OLE オブジェクトがすでに埋め込まれている場合、以下の手順で簡単に検索またはアクセスできます。 

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成して、埋め込み OLE オブジェクトを含むプレゼンテーションをロードします。 
2. インデックスを使用してスライドの参照を取得します。 
3. [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) シェイプにアクセスします。例では、1 枚目のスライドに 1 つのシェイプしかない以前に作成した PPTX を使用しました。 
4. OLE オブジェクトフレームにアクセスできたら、任意の操作を実行できます。 

以下の例では、OLE オブジェクトフレーム（スライドに埋め込まれた Excel チャートオブジェクト）とそのファイルデータにアクセスしています。  
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // 埋め込まれたファイルデータを取得します。
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // 埋め込まれたファイルの拡張子を取得します。
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```


### **リンクされた OLE オブジェクトフレームのプロパティへのアクセス**

Aspose.Slides では、リンクされた OLE オブジェクトフレームのプロパティにアクセスできます。  

以下の PHP コードは、OLE オブジェクトがリンクされているかを確認し、リンクされたファイルへのパスを取得する方法を示しています：  
```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // OLE オブジェクトがリンクされているか確認します。
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // リンクされたファイルへのフルパスを出力します。
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // 存在する場合はリンクされたファイルの相対パスを出力します。
        // 相対パスを含められるのは PPT プレゼンテーションだけです。
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```


## **OLE オブジェクト データの変更**

{{% alert color="primary" %}} 

このセクションでは、以下のコード例で [Aspose.Cells for PHP via Java](/cells/php-java/) を使用しています。  

{{% /alert %}} 

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成して、埋め込み OLE オブジェクトを含むプレゼンテーションをロードします。 
2. インデックスを使用してスライドの参照を取得します。 
3. [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) シェイプにアクセスします。例では、1 枚目のスライドに 1 つのシェイプしかない以前に作成した PPTX を使用しました。 
4. OLE オブジェクトフレームにアクセスできたら、任意の操作を実行できます。 
5. `Workbook` オブジェクトを作成し、OLE データにアクセスします。 
6. 目的の `Worksheet` にアクセスし、データを修正します。 
7. 更新した `Workbook` をストリームに保存します。 
8. ストリームから OLE オブジェクトのデータを変更します。 

以下の例では、OLE オブジェクトフレーム（スライドに埋め込まれた Excel チャートオブジェクト）にアクセスし、ファイルデータを変更してチャートデータを更新しています。  
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new ByteArrayInputStream($oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // OLE オブジェクトのデータを Workbook オブジェクトとして読み取ります。
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // Workbook のデータを変更します。
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // OLE フレームオブジェクトのデータを変更します。
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **スライドに他のファイルタイプを埋め込む**

Excel チャートに加えて、Aspose.Slides for PHP via Java では、スライドに他の種類のファイルを埋め込むことができます。たとえば、HTML、PDF、ZIP ファイルをオブジェクトとして挿入できます。ユーザーが挿入されたオブジェクトをダブルクリックすると、関連プログラムで自動的に開くか、開くプログラムの選択を求められます。  

以下の PHP コードは、HTML と ZIP をスライドに埋め込む方法を示しています：  
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$htmlData = file_get_contents("sample.html");
$htmlDataInfo = new OleEmbeddedDataInfo($htmlData, "html");
$htmlOleFrame = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $htmlDataInfo);
$htmlOleFrame->setObjectIcon(true);

$zipData = file_get_contents("sample.zip");
$zipDataInfo = new OleEmbeddedDataInfo($zipData, "zip");
$zipOleFrame = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $zipDataInfo);
$zipOleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **埋め込みオブジェクトのファイルタイプの設定**

プレゼンテーション作業中に、古い OLE オブジェクトを新しいものに置き換えたり、サポートされていない OLE オブジェクトをサポートされているものに置き換えたりする必要がある場合があります。Aspose.Slides for PHP via Java を使用すると、埋め込みオブジェクトのファイルタイプを設定でき、OLE フレームのデータや拡張子を更新できます。  

以下の PHP コードは、埋め込み OLE オブジェクトのファイルタイプを `zip` に設定する方法を示しています：  
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// Change the file type to ZIP.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **埋め込みオブジェクトのアイコン画像とタイトルの設定**

OLE オブジェクトを埋め込むと、アイコン画像で構成されたプレビューが自動的に追加されます。このプレビューは、ユーザーが OLE オブジェクトにアクセスまたは開く前に表示されるものです。特定の画像やテキストをプレビューに使用したい場合、Aspose.Slides for PHP via Java を使用してアイコン画像とタイトルを設定できます。  

以下の PHP コードは、埋め込みオブジェクトのアイコン画像とタイトルを設定する方法を示しています：  
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// プレゼンテーションのリソースに画像を追加します。
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// OLE プレビューのタイトルと画像を設定します。
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **OLE オブジェクトフレームがサイズ変更や位置変更されるのを防止**

リンクされた OLE オブジェクトをプレゼンテーションのスライドに追加した後、PowerPoint でプレゼンテーションを開くと、リンクの更新を求めるメッセージが表示されることがあります。「Update Links」ボタンをクリックすると、PowerPoint がリンクされた OLE オブジェクトのデータを更新しプレビューを再描画するため、OLE オブジェクトフレームのサイズや位置が変更されることがあります。PowerPoint がオブジェクトのデータ更新を促さないようにするには、[OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) クラスの `setUpdateAutomatic` メソッドを `false` に設定します：  
```php
$oleFrame->setUpdateAutomatic(false);
```


## **埋め込まれたファイルの抽出**

Aspose.Slides for PHP via Java を使用すると、スライドに埋め込まれたファイルを OLE オブジェクトとして以下の手順で抽出できます。  

1. 抽出したい OLE オブジェクトを含む [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。 
2. プレゼンテーション内のすべてのシェイプをループし、[OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) シェイプにアクセスします。 
3. OLE オブジェクトフレームから埋め込みファイルのデータにアクセスし、ディスクに書き出します。 

以下の PHP コードは、スライドに埋め込まれたファイルを OLE オブジェクトとして抽出する方法を示しています：  
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$shapeCount = java_values($slide->getShapes()->size());
for ($index = 0; $index < $shapeCount; $index++) {
    $shape = $slide->getShapes()->get_Item($index);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $oleFrame = $shape;

        $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

        $filePath = "OLE_object_" . $index . $fileExtension;
        file_put_contents($filePath, $fileData);
    }
}

$presentation->dispose();
```


## **FAQ**

**スライドを PDF/画像にエクスポートする際、OLE コンテンツはレンダリングされますか？**

スライド上に表示されているもの、すなわちアイコン/代替画像（プレビュー）がレンダリングされます。実際の「ライブ」OLE コンテンツはレンダリング時に実行されません。必要に応じて、期待通りの外観になるように独自のプレビュー画像を設定してください。  

**PowerPoint でユーザーが OLE オブジェクトを移動/編集できないようにロックするにはどうすればよいですか？**

シェイプをロックします。Aspose.Slides は [shape-level locks](/slides/ja/php-java/applying-protection-to-presentation/) を提供しています。これは暗号化ではありませんが、誤操作や移動を実質的に防止します。  

**リンクされた Excel オブジェクトがプレゼンテーションを開くと「ジャンプ」したりサイズが変わったりするのはなぜですか？**

PowerPoint はリンクされた OLE のプレビューを再描画することがあります。安定した外観を保つには、[Working Solution for Worksheet Resizing](/slides/ja/php-java/working-solution-for-worksheet-resizing/) の手順に従ってください。フレームを範囲に合わせるか、範囲を固定フレームにスケールし、適切な代替画像を設定します。  

**リンクされた OLE オブジェクトの相対パスは PPTX 形式で保持されますか？**

PPTX では「相対パス」情報は保持されず、フルパスのみが保存されます。相対パスは旧来の PPT 形式でのみ利用可能です。移植性を考える場合、信頼できる絶対パスやアクセス可能な URI、あるいは埋め込みを利用することを推奨します。