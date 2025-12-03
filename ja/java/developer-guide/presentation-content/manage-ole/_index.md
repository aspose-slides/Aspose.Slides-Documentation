---
title: Java を使用したプレゼンテーションでの OLE 管理
linktitle: OLE の管理
type: docs
weight: 40
url: /ja/java/manage-ole/
keywords:
- OLE オブジェクト
- オブジェクト リンキング & 埋め込み
- OLE を追加
- OLE を埋め込む
- オブジェクトを追加
- オブジェクトを埋め込む
- ファイルを追加
- ファイルを埋め込む
- リンクされたオブジェクト
- リンクされたファイル
- OLE を変更
- OLE アイコン
- OLE タイトル
- OLE を抽出
- オブジェクトを抽出
- ファイルを抽出
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument ファイル内の OLE オブジェクト管理を最適化します。OLE コンテンツをシームレスに埋め込み、更新、エクスポートできます。"
---

{{% alert color="primary" %}} 

OLE（Object Linking & Embedding）は、あるアプリケーションで作成されたデータやオブジェクトを、リンクまたは埋め込みにより別のアプリケーションに配置できるMicrosoftの技術です。

{{% /alert %}} 

MS Excelで作成されたグラフを考えてみてください。そのグラフがPowerPointのスライドに配置されます。そのExcelグラフはOLEオブジェクトと見なされます。

- OLEオブジェクトはアイコンとして表示されることがあります。この場合、アイコンをダブルクリックすると、チャートが関連付けられたアプリケーション（Excel）で開かれるか、オブジェクトの開閉や編集のためにアプリケーションの選択が求められます。
- OLEオブジェクトは実際の内容（例：チャートの内容）を表示することがあります。この場合、チャートはPowerPoint内でアクティブになり、チャートのインターフェイスがロードされ、PowerPoint内でチャートのデータを変更できます。

[Aspose.Slides for Java](https://products.aspose.com/slides/java/) は、スライドにOLEオブジェクトをOLEオブジェクトフレームとして挿入することを可能にします（[OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)）。

## **スライドへのOLEオブジェクトフレームの追加**

Microsoft Excelで既にチャートを作成し、Aspose.Slides for Javaを使用してOLEオブジェクトフレームとしてスライドに埋め込みたい場合、以下の手順で行うことができます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. スライドのインデックスを使用してスライドへの参照を取得します。
3. Excelファイルをバイト配列として読み取ります。
4. バイト配列およびOLEオブジェクトに関するその他の情報を含む[OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) をスライドに追加します。
5. 変更されたプレゼンテーションを書き出してPPTXファイルに保存します。

以下の例では、Excelファイルからチャートを取得し、Aspose.Slides for Javaを使用してOLEオブジェクトフレームとしてスライドに追加しました。  
**注意**: [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/OleEmbeddedDataInfo) コンストラクタは、第二パラメータとして埋め込めるオブジェクトの拡張子を受け取ります。この拡張子により、PowerPointはファイルタイプを正しく解釈し、このOLEオブジェクトを開く適切なアプリケーションを選択できます。  
``` java 
Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE オブジェクトのデータを準備します。
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


### **リンクされたOLEオブジェクトフレームの追加**

Aspose.Slides for Java を使用すると、データを埋め込まずにファイルへのリンクのみで[OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) を追加できます。

以下のJavaコードは、リンクされたExcelファイルを使用して[OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) をスライドに追加する方法を示しています。  
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// リンクされた Excel ファイルを使用して OLE オブジェクトフレームを追加します。
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **OLEオブジェクトフレームへのアクセス**

スライドにOLEオブジェクトが既に埋め込まれている場合、以下の方法で簡単に検索またはアクセスできます。

1. 埋め込みOLEオブジェクトを含むプレゼンテーションを、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成してロードします。
2. インデックスを使用してスライドの参照を取得します。
3. [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) シェイプにアクセスします。  
   本例では、最初のスライドに1つだけシェイプがある以前に作成したPPTXを使用しました。そのオブジェクトを[IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame) と*キャスト*しました。これがアクセス対象のOLEオブジェクトフレームです。
4. OLEオブジェクトフレームにアクセスしたら、任意の操作を実行できます。

以下の例では、OLEオブジェクトフレーム（スライドに埋め込まれたExcelチャートオブジェクト）とそのファイルデータにアクセスします。  
``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // 埋め込まれたファイルデータを取得します。
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // 埋め込まれたファイルの拡張子を取得します。
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```


### **リンクされたOLEオブジェクトフレームのプロパティへのアクセス**

Aspose.Slides を使用すると、リンクされたOLEオブジェクトフレームのプロパティにアクセスできます。

以下のJavaコードは、OLEオブジェクトがリンクされているかどうかを確認し、リンクされたファイルへのパスを取得する方法を示しています。  
```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // OLE オブジェクトがリンクされているか確認します。
    if (oleFrame.isObjectLink()) {
        // リンクされたファイルへのフルパスを出力します。
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // 存在する場合、リンクされたファイルへの相対パスを出力します。
        // 相対パスを含められるのは PPT プレゼンテーションのみです。
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```


## **OLEオブジェクトデータの変更**

{{% alert color="primary" %}} 

このセクションでは、以下のコード例で[Aspose.Cells for Java](/cells/java/) を使用しています。

{{% /alert %}}

スライドにOLEオブジェクトが既に埋め込まれている場合、以下の方法でそのオブジェクトにアクセスし、データを変更できます。

1. 埋め込みOLEオブジェクトを含むプレゼンテーションを、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成してロードします。
2. インデックスを使用してスライドの参照を取得します。
3. OLEオブジェクトフレームシェイプにアクセスします。  
   本例では、最初のスライドに1つのシェイプがある以前に作成したPPTXを使用しました。そのオブジェクトを[IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame) と*キャスト*しました。これがアクセス対象のOLEオブジェクトフレームです。
4. OLEオブジェクトフレームにアクセスしたら、任意の操作を実行できます。
5. `Workbook` オブジェクトを作成し、OLEデータにアクセスします。
6. 目的の `Worksheet` にアクセスし、データを修正します。
7. 更新された `Workbook` をストリームに保存します。
8. ストリームからOLEオブジェクトデータを変更します。

以下の例では、OLEオブジェクトフレーム（スライドに埋め込まれたExcelチャートオブジェクト）にアクセスし、ファイルデータを変更してチャートデータを更新します。  
``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // OLE オブジェクトのデータを Workbook オブジェクトとして読み取ります。
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Workbook のデータを変更します。
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // OLE フレームオブジェクトのデータを変更します。
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **スライドへの他のファイルタイプの埋め込み**

Excelチャートに加えて、Aspose.Slides for Java はスライドに他の種類のファイルを埋め込むことも可能です。たとえば、HTML、PDF、ZIP ファイルをオブジェクトとして挿入できます。ユーザーが挿入されたオブジェクトをダブルクリックすると、関連プログラムで自動的に開くか、適切なプログラムの選択を促されます。

以下のJavaコードは、HTML と ZIP をスライドに埋め込む方法を示しています。  
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

byte[] htmlData = Files.readAllBytes(Paths.get("sample.html"));
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

byte[] zipData = Files.readAllBytes(Paths.get("sample.zip"));
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **埋め込みオブジェクトのファイルタイプ設定**

プレゼンテーションを扱う際、古いOLEオブジェクトを新しいものに置き換えたり、サポートされていないOLEオブジェクトをサポートされたものに置き換える必要がある場合があります。Aspose.Slides for Java は、埋め込みオブジェクトのファイルタイプを設定でき、OLEフレームデータや拡張子を更新できます。

以下のJavaコードは、埋め込みOLEオブジェクトのファイルタイプを `zip` に設定する方法を示しています。  
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// ファイルタイプを ZIP に変更します。
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **埋め込みオブジェクトのアイコン画像とタイトルの設定**

OLEオブジェクトを埋め込むと、アイコン画像からなるプレビューが自動的に追加されます。このプレビューは、ユーザーがOLEオブジェクトにアクセスまたは開く前に表示されるものです。特定の画像とテキストをプレビュー要素として使用したい場合、Aspose.Slides for Java を使用してアイコン画像とタイトルを設定できます。

以下のJavaコードは、埋め込みオブジェクトのアイコン画像とタイトルを設定する方法を示しています。  
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// プレゼンテーションのリソースに画像を追加します。
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **OLEオブジェクトフレームのサイズ変更と位置変更を防止する**

リンクされたOLEオブジェクトをプレゼンテーションのスライドに追加した後、PowerPointでプレゼンテーションを開くと、リンクの更新を求めるメッセージが表示されることがあります。「Update Links」ボタンをクリックすると、PowerPointがリンクされたOLEオブジェクトのデータを更新し、オブジェクトのプレビューを再描画するため、OLEオブジェクトフレームのサイズや位置が変わることがあります。PowerPointがオブジェクトのデータ更新を促さないようにするには、[IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) インターフェイスの `setUpdateAutomatic` メソッドを `false` に設定します。  
```java
oleFrame.setUpdateAutomatic(false);
```


## **埋め込みファイルの抽出**

Aspose.Slides for Java では、スライドに埋め込まれたファイルをOLEオブジェクトとして以下の手順で抽出できます。

1. 抽出したいOLEオブジェクトを含む [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. プレゼンテーション内のすべてのシェイプをループし、[OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe) シェイプにアクセスします。
3. OLEオブジェクトフレームから埋め込みファイルのデータにアクセスし、ディスクに書き出します。

以下のJavaコードは、スライドに埋め込まれたファイルをOLEオブジェクトとして抽出する方法を示しています。  
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        Path filePath = Paths.get("OLE_object_" + index + fileExtension);
        Files.write(filePath, fileData);
    }
}

presentation.dispose();
```


## **FAQ**

**スライドを PDF/画像にエクスポートするときに OLE コンテンツはレンダリングされますか？**  
スライド上に表示されているもの、すなわちアイコンや代替画像（プレビュー）がレンダリングされます。実際の OLE コンテンツはレンダリング時に実行されません。必要に応じて、独自のプレビュー画像を設定し、エクスポートされた PDF で期待通りに表示されるようにしてください。

**PowerPoint でユーザーが OLE オブジェクトを移動・編集できないようにロックするにはどうすればよいですか？**  
シェイプをロックします。Aspose.Slides は [shape-level locks](/slides/ja/java/applying-protection-to-presentation/) を提供しています。これは暗号化ではありませんが、誤操作による編集や移動を効果的に防止します。

**リンクされた Excel オブジェクトがプレゼンテーションを開くと「ジャンプ」したりサイズが変わったりするのはなぜですか？**  
PowerPoint はリンクされた OLE のプレビューを更新することがあります。安定した外観を保つには、[Working Solution for Worksheet Resizing](/slides/ja/java/working-solution-for-worksheet-resizing/) の手法に従い、フレームを範囲に合わせるか、範囲を固定フレームにスケーリングし、適切な代替画像を設定してください。

**リンクされた OLE オブジェクトの相対パスは PPTX 形式で保持されますか？**  
PPTX では「相対パス」情報は保持されず、フルパスのみが使用されます。相対パスは古い PPT 形式でのみ利用可能です。可搬性を考慮する場合、信頼できる絶対パスやアクセス可能な URI、あるいは埋め込みを使用することを推奨します。