---
title: Java を使用したプレゼンテーションでの OLE 管理
linktitle: OLE の管理
type: docs
weight: 40
url: /ja/java/manage-ole/
keywords:
- OLE オブジェクト
- オブジェクトリンクと埋め込み
- OLE の追加
- OLE の埋め込み
- オブジェクトの追加
- オブジェクトの埋め込み
- ファイルの追加
- ファイルの埋め込み
- リンクされたオブジェクト
- リンクされたファイル
- OLE の変更
- OLE アイコン
- OLE タイトル
- OLE の抽出
- オブジェクトの抽出
- ファイルの抽出
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument ファイルの OLE オブジェクト管理を最適化します。OLE コンテンツをシームレスに埋め込み、更新、エクスポートできます。"
---
## **概要**

{{% alert color="info" %}} 

OLE (Object Linking & Embedding) は、1 つのアプリケーションで作成されたデータやオブジェクトを、リンクまたは埋め込みにより別のアプリケーションに配置できる Microsoft の技術です。

{{% /alert %}} 

MS Excel で作成したチャートを考えてみてください。そのチャートを PowerPoint のスライドに配置します。この Excel のチャートは OLE オブジェクトとして扱われます。

- OLE オブジェクトはアイコンとして表示されることがあります。この場合、アイコンをダブルクリックすると、チャートは関連付けられたアプリケーション (Excel) で開かれるか、オブジェクトを開くまたは編集するアプリケーションの選択を求められます。  
- OLE オブジェクトは実際の内容（例: チャートの内容）を表示することがあります。この場合、PowerPoint 内でチャートがアクティブになり、チャート インターフェイスが読み込まれ、PowerPoint 上でチャートのデータを変更できます。

[Aspose.Slides for Java](https://products.aspose.com/slides/ja/java/) は、スライドに OLE オブジェクトを OLE オブジェクト フレームとして挿入できるようにします（[OleObjectFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/OleObjectFrame)）。

## **スライドへの OLE オブジェクト フレームの追加**

すでに Microsoft Excel でチャートを作成し、Aspose.Slides for Java を使用して OLE オブジェクト フレームとしてスライドに埋め込む場合、次の手順で実行できます。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. Excel ファイルをバイト配列として読み取ります。  
4. バイト配列および OLE オブジェクトに関するその他の情報を含めて、スライドに [OleObjectFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/OleObjectFrame) を追加します。  
5. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、Excel ファイルからチャートを取得し、Aspose.Slides for Java を使用してスライドに OLE オブジェクト フレームとして追加しています。  
**Note** [OleEmbeddedDataInfo](https://reference.aspose.com/slides/ja/java/com.aspose.slides/OleEmbeddedDataInfo) コンストラクターは、2 番目のパラメーターとして埋め込み可能なオブジェクト拡張子を受け取ります。この拡張子により、PowerPoint はファイルの種類を正しく解釈し、適切なアプリケーションで OLE オブジェクトを開くことができます。

``` java 
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **リンクされた OLE オブジェクト フレームの追加**

Aspose.Slides for Java は、データを埋め込まずにファイルへのリンクだけで [OleObjectFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/OleObjectFrame) を追加できます。

次の Java コードは、リンクされた Excel ファイルを持つ [OleObjectFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/OleObjectFrame) をスライドに追加する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// リンクされた Excel ファイルで OLE オブジェクト フレームを追加します。
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE オブジェクト フレームへのアクセス**

スライドに OLE オブジェクトがすでに埋め込まれている場合、次の手順で簡単に見つけてアクセスできます。

1. 埋め込まれた OLE オブジェクトを含むプレゼンテーションを、[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) クラスのインスタンスを作成してロードします。  
2. インデックスを使用してスライドの参照を取得します。  
3. [OleObjectFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/OleObjectFrame) シェイプへアクセスします。例では、最初のスライドに 1 つだけシェイプがある事前に作成された PPTX を使用し、そのオブジェクトを [IOleObjectFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IOleObjectFrame) に *cast* しています。これが目的の OLE オブジェクト フレームです。  
4. OLE オブジェクト フレームにアクセスできたら、任意の操作を実行できます。

以下の例では、スライドに埋め込まれた OLE オブジェクト フレーム（Excel のチャート オブジェクト）とそのファイル データにアクセスしています。

``` java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // 埋め込まれたファイル データを取得します。
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // 埋め込まれたファイルの拡張子を取得します。
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **リンクされた OLE オブジェクト フレーム プロパティへのアクセス**

Aspose.Slides は、リンクされた OLE オブジェクト フレームのプロパティにアクセスできます。

次の Java コードは、OLE オブジェクトがリンクされているかどうかを確認し、リンク先ファイルのパスを取得する方法を示しています。

```java
import com.aspose.slides.*;

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
        // 相対パスを含められるのは PPT プレゼンテーションだけです。
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE オブジェクト データの変更**

{{% alert color="info" %}} 

このセクションのコード例は、[Aspose.Cells for Java](/cells/java/) を使用しています。

{{% /alert %}}

スライドに OLE オブジェクトがすでに埋め込まれている場合、次の手順でそのオブジェクトにアクセスし、データを変更できます。

1. 埋め込まれた OLE オブジェクトを含むプレゼンテーションを、[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) クラスのインスタンスを作成してロードします。  
2. インデックスを使用してスライドの参照を取得します。  
3. OLE オブジェクト フレーム シェイプへアクセスします。例では、最初のスライドに 1 つだけシェイプがある事前に作成された PPTX を使用し、そのオブジェクトを [IOleObjectFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IOleObjectFrame) に *cast* しています。これが目的の OLE オブジェクト フレームです。  
4. OLE オブジェクト フレームにアクセスできたら、任意の操作を実行できます。  
5. `Workbook` オブジェクトを作成し、OLE データにアクセスします。  
6. 対象の `Worksheet` にアクセスし、データを修正します。  
7. 更新された `Workbook` をストリームに保存します。  
8. ストリームから OLE オブジェクト データを変更します。

以下の例では、スライドに埋め込まれた OLE オブジェクト フレーム（Excel のチャート オブジェクト）にアクセスし、ファイル データを変更してチャート データを更新しています。

``` java 
import com.aspose.slides.*;
import com.aspose.cells.Workbook;
import com.aspose.cells.OoxmlSaveOptions;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // OLE オブジェクト データを Workbook オブジェクトとして読み取ります。
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Workbook のデータを変更します。
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // OLE フレーム オブジェクト データを変更します。
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **スライドへの他のファイル種類の埋め込み**

Excel チャートに加えて、Aspose.Slides for Java はスライドにさまざまな種類のファイルを埋め込むことができます。たとえば、HTML、PDF、ZIP ファイルをオブジェクトとして挿入できます。ユーザーが挿入されたオブジェクトをダブルクリックすると、関連プログラムで自動的に開くか、適切なプログラムを選択するように促されます。

次の Java コードは、HTML と ZIP をスライドに埋め込む方法を示しています。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

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

## **埋め込みオブジェクトのファイル種別の設定**

プレゼンテーションを扱う際、古い OLE オブジェクトを新しいものに置き換えたり、サポートされていない OLE オブジェクトをサポートされているものに置き換える必要がある場合があります。Aspose.Slides for Java は、埋め込みオブジェクトのファイル種別を設定できるため、OLE フレーム データや拡張子を更新できます。

次の Java コードは、埋め込み OLE オブジェクトのファイル種別を `zip` に設定する方法を示しています。

```java
import com.aspose.slides.*;

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

OLE オブジェクトを埋め込むと、自動的にアイコン画像で構成されたプレビューが追加されます。このプレビューは、ユーザーが OLE オブジェクトにアクセスまたは開く前に表示されるものです。特定の画像とテキストをプレビューに使用したい場合は、Aspose.Slides for Java を使用してアイコン画像とタイトルを設定できます。

次の Java コードは、埋め込みオブジェクトのアイコン画像とタイトルを設定する方法を示しています。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// プレゼンテーションのリソースに画像を追加します。
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// OLE プレビュー用にタイトルと画像を設定します。
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE オブジェクト フレームのサイズと位置の自動変更を防止する**

リンクされた OLE オブジェクトをプレゼンテーション スライドに追加した後、PowerPoint でプレゼンテーションを開くと、リンクの更新を求めるメッセージが表示されることがあります。「Update Links」ボタンをクリックすると、PowerPoint がリンクされた OLE オブジェクトからデータを更新し、プレビューを再描画するため、OLE オブジェクト フレームのサイズと位置が変更されることがあります。PowerPoint がオブジェクトのデータ更新を促さないようにするには、[IOleObjectFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ioleobjectframe/) インターフェイスの `setUpdateAutomatic` メソッドを `false` に設定します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **埋め込みファイルの抽出**

Aspose.Slides for Java は、スライドに OLE オブジェクトとして埋め込まれたファイルを次の手順で抽出できます。

1. 抽出対象の OLE オブジェクトを含む [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. プレゼンテーション内のすべてのシェイプをループし、[OLEObjectFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/oleobjectframe) シェイプにアクセスします。  
3. OLE オブジェクト フレームから埋め込みファイルのデータを取得し、ディスクに書き出します。

次の Java コードは、スライドに埋め込まれた OLE オブジェクトとしてのファイルを抽出する方法を示しています。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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

### スライドを PDF/画像にエクスポートするとき、OLE コンテンツはレンダリングされますか？

スライド上に表示されているもの、つまりアイコン/代替画像（プレビュー）だけがレンダリングされます。「ライブ」な OLE コンテンツはレンダリング時に実行されません。必要に応じて、エクスポートされた PDF で期待通りの外観になるよう、独自のプレビュー画像を設定してください。

### PowerPoint でユーザーが OLE オブジェクトを移動/編集できないようにロックするにはどうすればよいですか？

シェイプをロックします。Aspose.Slides は [シェイプ レベルのロック](/slides/ja/java/applying-protection-to-presentation/) を提供しています。これは暗号化ではありませんが、誤って編集や移動することを実質的に防止します。

### リンクされた Excel オブジェクトを開くと「ジャンプ」したりサイズが変わったりするのはなぜですか？

PowerPoint がリンクされた OLE のプレビューを再描画することがあります。安定した表示を保つには、[Worksheet Resizing の実装例](/slides/ja/java/working-solution-for-worksheet-resizing/) に従い、フレームを範囲に合わせるか、範囲を固定フレームに合わせてスケーリングし、適切な代替画像を設定してください。

### PPTX 形式でリンクされた OLE オブジェクトの相対パスは保持されますか？

PPTX では「相対パス」情報は保持されず、フル パスのみが保存されます。相対パスは古い PPT 形式でのみ利用可能です。移植性を確保するには、信頼できる絶対パス／アクセス可能な URI を使用するか、埋め込みを検討してください。