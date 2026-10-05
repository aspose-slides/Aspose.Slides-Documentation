---
title: Java を使用したプレゼンテーションでの OLE 管理
linktitle: OLE の管理
type: docs
weight: 40
url: /ja/java/manage-ole/
keywords:
- OLE オブジェクト
- オブジェクト リンキングと埋め込み
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
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument ファイルにおける OLE オブジェクトの管理を最適化します。OLE コンテンツをシームレスに埋め込み、更新し、エクスポートできます。"
---
## **イントロダクション**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) は、あるアプリケーションで作成されたデータやオブジェクトを、リンクまたは埋め込みによって別のアプリケーションに配置できる Microsoft の技術です。

{{% /alert %}} 

MS Excel で作成されたチャートを考えてみてください。そのチャートを PowerPoint のスライドに配置します。この Excel チャートは OLE オブジェクトと見なされます。

- OLE オブジェクトはアイコンとして表示されることがあります。この場合、アイコンをダブルクリックすると、チャートは関連付けられたアプリケーション (Excel) で開くか、オブジェクトを開くまたは編集するアプリケーションの選択が求められます。
- OLE オブジェクトは実際の内容、たとえばチャートそのものを表示することがあります。この場合、PowerPoint でチャートがアクティブになり、チャートのインターフェイスがロードされ、PowerPoint 内でチャートのデータを変更できます。

[Aspose.Slides for Java](https://products.aspose.com/slides/java/) を使用すると、スライドに OLE オブジェクトを OLE オブジェクトフレーム ([OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)) として挿入できます。

## **スライドへの OLE オブジェクトフレームの追加**

Microsoft Excel で既にチャートを作成し、Aspose.Slides for Java を使用して OLE オブジェクトフレームとしてスライドに埋め込みたい場合、次の手順で実行できます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドへの参照を取得します。
1. Excel ファイルをバイト配列として読み取ります。
1. バイト配列と OLE オブジェクトに関するその他の情報を含む [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) をスライドに追加します。
1. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、Excel ファイルからチャートを取得し、Aspose.Slides for Java を使用して OLE オブジェクトフレームとしてスライドに追加しています。  
**注**: [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/OleEmbeddedDataInfo) コンストラクタは、2 番目のパラメータとして埋め込み可能なオブジェクト拡張子を受け取ります。この拡張子により、PowerPoint はファイル形式を正しく解釈し、適切なアプリケーションで OLE オブジェクトを開くことができます。

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

### **リンクされた OLE オブジェクトフレームの追加**

Aspose.Slides for Java を使用すると、データを埋め込まずにファイルへのリンクだけで [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) を追加できます。

この Java コードは、リンクされた Excel ファイルを含む [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) をスライドに追加する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// リンクされた Excel ファイルを使用して OLE オブジェクト フレームを追加します。
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE オブジェクトフレームへのアクセス**

スライドに OLE オブジェクトが既に埋め込まれている場合、次の手順で簡単に見つけてアクセスできます。

1. 埋め込まれた OLE オブジェクトを含むプレゼンテーションを、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成してロードします。
2. インデックスを使用してスライドへの参照を取得します。
3. [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) シェイプにアクセスします。例では、最初のスライドに 1 つだけシェイプがある PPTX を使用し、そのオブジェクトを [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame) と *cast* しています。これが目的の OLE オブジェクトフレームです。
4. OLE オブジェクトフレームにアクセスできたら、任意の操作を実行できます。

以下の例では、スライドに埋め込まれた Excel チャートオブジェクトとそのファイル データにアクセスしています。

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

### **リンクされた OLE オブジェクトフレーム プロパティへのアクセス**

Aspose.Slides では、リンクされた OLE オブジェクトフレームのプロパティにアクセスできます。

この Java コードは、OLE オブジェクトがリンクされているかどうかを確認し、リンク先ファイルへのパスを取得する方法を示しています。

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

{{% alert color="info" title="Note" %}}

このセクションのコード例は、[Aspose.Cells for Java](https://docs.aspose.com/cells/java/) を使用しています。

{{% /alert %}}

スライドに OLE オブジェクトが既に埋め込まれている場合、次の手順でオブジェクトにアクセスし、そのデータを変更できます。

1. 埋め込まれた OLE オブジェクトを含むプレゼンテーションを、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成してロードします。
2. インデックスを使用してスライドへの参照を取得します。 
3. OLE オブジェクトフレーム シェイプにアクセスします。例では、最初のスライドに 1 つだけシェイプがある PPTX を使用し、そのオブジェクトを [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame) と *cast* しています。これが目的の OLE オブジェクトフレームです。
4. OLE オブジェクトフレームにアクセスできたら、任意の操作を実行できます。
5. `Workbook` オブジェクトを作成し、OLE データにアクセスします。
6. 対象の `Worksheet` にアクセスし、データを修正します。
7. 更新された `Workbook` をストリームに保存します。
8. ストリームから OLE オブジェクト データを変更します。

以下の例では、スライドに埋め込まれた Excel チャートオブジェクトにアクセスし、ファイル データを変更してチャート データを更新しています。

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

    // Workbook データを変更します。
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

## **スライドへの他のファイルタイプの埋め込み**

Excel チャート以外にも、Aspose.Slides for Java を使用してスライドにさまざまなファイルタイプを埋め込むことができます。たとえば、HTML、PDF、ZIP ファイルをオブジェクトとして挿入できます。ユーザーが挿入されたオブジェクトをダブルクリックすると、関連プログラムで自動的に開くか、適切なプログラムを選択するよう求められます。

この Java コードは、HTML と ZIP をスライドに埋め込む方法を示しています。

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

## **埋め込みオブジェクトのファイルタイプ設定**

プレゼンテーションの作業中に、古い OLE オブジェクトを新しいものに置き換えたり、サポートされていない OLE オブジェクトをサポートされたものに置き換えたりする必要がある場合があります。Aspose.Slides for Java を使用すると、埋め込みオブジェクトのファイルタイプを設定でき、OLE フレーム データまたは拡張子を更新できます。

この Java コードは、埋め込まれた OLE オブジェクトのファイルタイプを `zip` に設定する方法を示しています。

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

## **埋め込みオブジェクトのアイコン画像とタイトル設定**

OLE オブジェクトを埋め込むと、デフォルトでアイコン画像のプレビューが自動的に追加されます。このプレビューは、ユーザーが OLE オブジェクトにアクセスまたは開く前に表示されるものです。特定の画像とテキストをプレビューに使用したい場合は、Aspose.Slides for Java を使用してアイコン画像とタイトルを設定できます。

この Java コードは、埋め込まれたオブジェクトのアイコン画像とタイトルを設定する方法を示しています。

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

## **OLE オブジェクトフレームのサイズ変更と再配置の防止**

リンクされた OLE オブジェクトをプレゼンテーション スライドに追加した後、PowerPoint でプレゼンテーションを開くと「リンクの更新」メッセージが表示されることがあります。「更新」ボタンをクリックすると、PowerPoint がリンクされた OLE オブジェクトからデータを取得してプレビューを更新するため、OLE オブジェクトフレームのサイズや位置が変更されることがあります。PowerPoint がオブジェクトのデータ更新を促さないようにするには、[IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) インターフェイスの [setUpdateAutomatic](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) メソッドに `false` を渡して呼び出します。

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

Aspose.Slides for Java を使用すると、スライドに埋め込まれた OLE オブジェクトとしてのファイルを次の手順で抽出できます。

1. 抽出対象の OLE オブジェクトを含む [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. プレゼンテーション内のすべてのシェイプをループし、[OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe) シェイプにアクセスします。
3. 埋め込まれたファイルのデータにアクセスし、ディスクに書き出します。

この Java コードは、スライドに埋め込まれたファイルを OLE オブジェクトとして抽出する方法を示しています。

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

**OLE コンテンツはスライドを PDF/画像にエクスポートする際にレンダリングされますか？**

スライド上に表示されているもの、つまりアイコン/代替画像 (プレビュー) がレンダリングされます。「ライブ」な OLE コンテンツはレンダリング時に実行されません。必要に応じて、期待通りの外観になるよう独自のプレビュー画像を設定してください。

埋め込まれたファイルを PDF 添付として保持したい場合は、`true` を指定して [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) を呼び出します。このオプションはデフォルトで無効です。例と添付ファイルの確認手順については、[埋め込み OLE ファイルを PDF 添付として保持](/slides/ja/java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments) を参照してください。

**PowerPoint でユーザーが OLE オブジェクトを移動/編集できないようにロックするには？**

シェイプをロックします。Aspose.Slides は [形状レベルのロック](/slides/ja/java/applying-protection-to-presentation/) を提供しています。これは暗号化ではありませんが、誤操作や移動を実質的に防止します。

**リンクされた Excel オブジェクトを開くと「ジャンプ」したりサイズが変わったりするのはなぜですか？**

PowerPoint がリンクされた OLE のプレビューをリフレッシュするためです。安定した外観を保つには、[ワークシートのサイズ変更に対する実用的解決策](/slides/ja/java/working-solution-for-worksheet-resizing/) の手順に従い、フレームを範囲に合わせるか、範囲を固定フレームにスケールして適切な代替画像を設定してください。

**リンクされた OLE オブジェクトの相対パスは PPTX 形式で保持されますか？**

PPTX では「相対パス」情報は保持されません。フルパスのみが記録されます。相対パスは旧式の PPT 形式でのみ利用可能です。可搬性を確保するため、信頼できる絶対パスまたはアクセス可能な URI、あるいは埋め込み方式を使用してください。