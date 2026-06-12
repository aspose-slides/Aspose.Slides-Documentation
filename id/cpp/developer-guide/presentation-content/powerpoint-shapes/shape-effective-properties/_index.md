---
title: Dapatkan Properti Bentuk Efektif dari Presentasi dalam C++
linktitle: Properti Efektif
type: docs
weight: 50
url: /id/cpp/shape-effective-properties/
keywords:
- properti bentuk
- properti kamera
- rig cahaya
- bentuk bevel
- bingkai teks
- gaya teks
- tinggi font
- format isian
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Temukan bagaimana Aspose.Slides untuk C++ menghitung dan menerapkan properti bentuk efektif untuk rendering PowerPoint yang akurat."
---
## **Gambaran Umum**

Topik ini menjelaskan perbedaan antara properti **lokal** dan **efektif**. Nilai lokal adalah nilai yang ditetapkan langsung pada tingkat pemformatan tertentu, seperti:

1. Properti bagian pada slide.
1. Gaya teks bentuk prototipe pada tata letak atau slide master, ketika bentuk bingkai teks bagian memiliki satu.
1. Pengaturan teks global dalam sebuah presentasi.

Nilai lokal dapat didefinisikan atau dihilangkan pada level apa pun. Ketika Aspose.Slides memerlukan pemformatan akhir "seperti yang ditampilkan", ia menyelesaikan rantai pewarisan dan mengembalikan nilai **efektif**. Anda dapat memperolehnya dengan memanggil metode `GetEffective` pada objek format lokal.

Contoh berikut menunjukkan cara memperoleh nilai efektif. Asumsinya, bentuk pertama pada slide pertama adalah sebuah [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/) dengan bingkai teks dan setidaknya satu bagian.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto textFrame = shape->get_TextFrame();
auto effectiveTextFrameFormat = textFrame->get_TextFrameFormat()->GetEffective();

auto portion = textFrame->get_Paragraph(0)->get_Portion(0);
auto effectivePortionFormat = portion->get_PortionFormat()->GetEffective();

presentation->Dispose();
```

{{% alert color="primary" %}}
Data pemformatan efektif mewakili pemformatan terhitung saat ini setelah pewarisan diterapkan. Dalam implementasi saat ini, beberapa objek data efektif, seperti [IPortionFormatEffectiveData](https://reference.aspose.com/slides/id/cpp/aspose.slides/iportionformateffectivedata/), mungkin disimpan dalam cache secara internal. Memanggil `GetEffective` lagi setelah mengubah pemformatan induk atau yang diwarisi dapat menyegarkan data yang di-cache, dan objek yang sebelumnya diperoleh mungkin tidak lagi mewakili keadaan sebelumnya. Jika Anda perlu mempertahankan nilai efektif untuk penggunaan di kemudian hari, salin properti yang diperlukan, seperti tinggi font, warna isian, gaya font, atau perataan, ke dalam objek data Anda sendiri.
{{% /alert %}}

## **Dapatkan Properti Efektif Kamera**

Aspose.Slides memungkinkan Anda memperoleh properti efektif kamera. Antarmuka [ICameraEffectiveData](https://reference.aspose.com/slides/id/cpp/aspose.slides/icameraeffectivedata/) mewakili objek tak dapat diubah yang berisi properti kamera efektif. Sebuah instansi [ICameraEffectiveData](https://reference.aspose.com/slides/id/cpp/aspose.slides/icameraeffectivedata/) diekspos melalui [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/id/cpp/aspose.slides/ithreedformateffectivedata/), yang menyediakan nilai efektif untuk [IThreeDFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/ithreedformat/).

Contoh kode berikut menunjukkan cara memperoleh properti efektif untuk kamera. Asumsinya, bentuk pertama pada slide pertama memiliki pemformatan 3D.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto camera = threeDEffectiveData->get_Camera();

System::Console::WriteLine(u"= Effective camera properties =");
auto cameraType = System::ObjectExt::ToString(camera->get_CameraType());
System::Console::WriteLine(System::String(u"Type: ") + cameraType);

auto fieldOfViewAngle = camera->get_FieldOfViewAngle();
System::Console::WriteLine(System::String(u"Field of view: ") + fieldOfViewAngle);

auto cameraZoom = camera->get_Zoom();
System::Console::WriteLine(System::String(u"Zoom: ") + cameraZoom);

presentation->Dispose();
```

## **Dapatkan Properti Efektif Rig Cahaya**

Aspose.Slides memungkinkan Anda memperoleh properti efektif rig cahaya. Antarmuka [ILightRigEffectiveData](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilightrigeffectivedata/) mewakili objek tak dapat diubah yang berisi properti rig cahaya efektif. Sebuah instansi [ILightRigEffectiveData](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilightrigeffectivedata/) diekspos melalui [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/id/cpp/aspose.slides/ithreedformateffectivedata/), yang menyediakan nilai efektif untuk [IThreeDFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/ithreedformat/).

Contoh kode berikut menunjukkan cara memperoleh properti efektif untuk rig cahaya. Asumsinya, bentuk pertama pada slide pertama memiliki pemformatan 3D.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto lightRig = threeDEffectiveData->get_LightRig();

System::Console::WriteLine(u"= Effective light rig properties =");
auto lightType = System::ObjectExt::ToString(lightRig->get_LightType());
System::Console::WriteLine(System::String(u"Type: ") + lightType);

auto lightDirection = System::ObjectExt::ToString(lightRig->get_Direction());
System::Console::WriteLine(System::String(u"Direction: ") + lightDirection);

presentation->Dispose();
```

## **Dapatkan Properti Efektif Bentuk Bevel**

Aspose.Slides memungkinkan Anda memperoleh properti efektif bentuk bevel. Antarmuka [IShapeBevelEffectiveData](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapebeveleffectivedata/) mewakili objek tak dapat diubah yang berisi properti relief wajah efektif untuk sebuah bentuk. Sebuah instansi [IShapeBevelEffectiveData](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapebeveleffectivedata/) diekspos melalui [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/id/cpp/aspose.slides/ithreedformateffectivedata/), yang menyediakan nilai efektif untuk [IThreeDFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/ithreedformat/).

Contoh kode berikut menunjukkan cara memperoleh properti efektif untuk bevel atas sebuah bentuk. Asumsinya, bentuk pertama pada slide pertama memiliki pemformatan 3D.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto bevelTop = threeDEffectiveData->get_BevelTop();

System::Console::WriteLine(u"= Effective shape's top face relief properties =");
auto bevelType = System::ObjectExt::ToString(bevelTop->get_BevelType());
System::Console::WriteLine(System::String(u"Type: ") + bevelType);

auto bevelWidth = bevelTop->get_Width();
System::Console::WriteLine(System::String(u"Width: ") + bevelWidth);

auto bevelHeight = bevelTop->get_Height();
System::Console::WriteLine(System::String(u"Height: ") + bevelHeight);

presentation->Dispose();
```

## **Dapatkan Properti Efektif Bingkai Teks**

Menggunakan Aspose.Slides, Anda dapat memperoleh properti efektif bingkai teks. Antarmuka [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframeformateffectivedata/) berisi properti pemformatan bingkai teks efektif.

Contoh kode berikut menunjukkan cara memperoleh properti pemformatan bingkai teks efektif. Asumsinya, bentuk pertama pada slide pertama adalah sebuah [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/) dengan bingkai teks.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto effectiveTextFrameFormat = shape->get_TextFrame()->get_TextFrameFormat()->GetEffective();

auto anchoringType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AnchoringType());
System::Console::WriteLine(System::String(u"Anchoring type: ") + anchoringType);

auto autofitType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AutofitType());
System::Console::WriteLine(System::String(u"Autofit type: ") + autofitType);

auto textVerticalType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_TextVerticalType());
System::Console::WriteLine(System::String(u"Text vertical type: ") + textVerticalType);

System::Console::WriteLine(u"Margins");
auto marginLeft = effectiveTextFrameFormat->get_MarginLeft();
System::Console::WriteLine(System::String(u"   Left: ") + marginLeft);

auto marginTop = effectiveTextFrameFormat->get_MarginTop();
System::Console::WriteLine(System::String(u"   Top: ") + marginTop);

auto marginRight = effectiveTextFrameFormat->get_MarginRight();
System::Console::WriteLine(System::String(u"   Right: ") + marginRight);

auto marginBottom = effectiveTextFrameFormat->get_MarginBottom();
System::Console::WriteLine(System::String(u"   Bottom: ") + marginBottom);

presentation->Dispose();
```

## **Dapatkan Properti Efektif Gaya Teks**

Menggunakan Aspose.Slides, Anda dapat memperoleh properti efektif gaya teks. Antarmuka [ITextStyleEffectiveData](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextstyleeffectivedata/) berisi properti gaya teks efektif.

Contoh kode berikut menunjukkan cara memperoleh properti gaya teks efektif. Asumsinya, bentuk pertama pada slide pertama adalah sebuah [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/) dengan bingkai teks.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto effectiveTextStyle = shape->get_TextFrame()->get_TextFrameFormat()->get_TextStyle()->GetEffective();
int levelCount = 9;

for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    auto effectiveStyleLevel = effectiveTextStyle->GetLevel(levelIndex);

    auto depth = effectiveStyleLevel->get_Depth();
    auto indent = effectiveStyleLevel->get_Indent();
    auto alignment = System::ObjectExt::ToString(effectiveStyleLevel->get_Alignment());
    auto fontAlignment = System::ObjectExt::ToString(effectiveStyleLevel->get_FontAlignment());

    System::Console::WriteLine(System::String(u"= Effective paragraph formatting for style level #") + levelIndex + u" =");
    System::Console::WriteLine(System::String(u"Depth: ") + depth);
    System::Console::WriteLine(System::String(u"Indent: ") + indent);
    System::Console::WriteLine(System::String(u"Alignment: ") + alignment);
    System::Console::WriteLine(System::String(u"Font alignment: ") + fontAlignment);
}

presentation->Dispose();
```

## **Dapatkan Nilai Tinggi Font Efektif**

Menggunakan Aspose.Slides, Anda dapat memperoleh tinggi font yang efektif. Kode berikut menunjukkan bagaimana tinggi font efektif sebuah bagian berubah setelah nilai tinggi font lokal diatur pada tingkat struktur presentasi yang berbeda.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 400.0f, 75.0f, false);
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portions = paragraph->get_Portions();
portions->Clear();

auto firstPortion = System::MakeObject<Portion>(u"Sample text with first portion");
auto secondPortion = System::MakeObject<Portion>(u" and second portion.");

portions->Add(firstPortion);
portions->Add(secondPortion);

System::Console::WriteLine(u"Effective font height just after creation:");
auto firstPortionFormat = firstPortion->get_PortionFormat();
auto secondPortionFormat = secondPortion->get_PortionFormat();

auto printEffectiveFontHeights = [&]()
{
    auto firstPortionFontHeight = firstPortionFormat->GetEffective()->get_FontHeight();
    auto secondPortionFontHeight = secondPortionFormat->GetEffective()->get_FontHeight();

    System::Console::WriteLine(System::String(u"Portion #0: ") + firstPortionFontHeight);
    System::Console::WriteLine(System::String(u"Portion #1: ") + secondPortionFontHeight);
};

printEffectiveFontHeights();

presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(24.0f);

System::Console::WriteLine(u"Effective font height after setting the presentation default font height:");
printEffectiveFontHeights();

paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(40.0f);

System::Console::WriteLine(u"Effective font height after setting paragraph default font height:");
printEffectiveFontHeights();

firstPortionFormat->set_FontHeight(55.0f);

System::Console::WriteLine(u"Effective font height after setting portion #0 font height:");
printEffectiveFontHeights();

secondPortionFormat->set_FontHeight(18.0f);

System::Console::WriteLine(u"Effective font height after setting portion #1 font height:");
printEffectiveFontHeights();

presentation->Save(u"SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Dapatkan Format Isian Efektif untuk Tabel**

Menggunakan Aspose.Slides, Anda dapat memperoleh pemformatan isian efektif untuk berbagai bagian tabel. Antarmuka [IFillFormatEffectiveData](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifillformateffectivedata/) berisi properti pemformatan isian efektif. Pemformatan sel memiliki prioritas lebih tinggi daripada pemformatan baris, pemformatan baris memiliki prioritas lebih tinggi daripada pemformatan kolom, dan pemformatan kolom memiliki prioritas lebih tinggi daripada pemformatan seluruh tabel.

Sebagai hasilnya, properti [ICellFormatEffectiveData](https://reference.aspose.com/slides/id/cpp/aspose.slides/icellformateffectivedata/) digunakan untuk menggambar sel tabel. Contoh kode berikut menunjukkan cara memperoleh pemformatan isian efektif untuk berbagai bagian tabel. Asumsinya, bentuk pertama pada slide pertama adalah sebuah [ITable](https://reference.aspose.com/slides/id/cpp/aspose.slides/itable/).

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto tableFillFormatEffective = table->get_TableFormat()->GetEffective()->get_FillFormat();
auto rowFillFormatEffective = table->get_Row(0)->get_RowFormat()->GetEffective()->get_FillFormat();
auto columnFillFormatEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective()->get_FillFormat();
auto cellFillFormatEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective()->get_FillFormat();

presentation->Dispose();
```

## **FAQ**

**Apakah `GetEffective` mengembalikan snapshot?**

Tidak selalu. Data efektif mewakili pemformatan yang dihitung setelah pewarisan diterapkan, tetapi beberapa objek data efektif dapat disimpan dalam cache secara internal. Panggilan `GetEffective` berikutnya mungkin menghitung ulang pemformatan dan menyegarkan data yang di-cache, sehingga objek yang sebelumnya diperoleh tidak boleh dianggap sebagai snapshot yang tahan lama.

**Kapan saya harus membaca kembali properti efektif?**

Panggil `GetEffective` lagi setelah mengubah pemformatan lokal, gaya induk, pemformatan tata letak, pemformatan master, atau nilai default pada tingkat presentasi. Panggilan berikutnya akan mengevaluasi kembali hierarki pemformatan dan mengembalikan hasil efektif saat ini.

**Apakah mengubah atau menghapus slide tata letak/master memengaruhi properti efektif yang sudah diambil?**

Ya, tetapi perubahan tersebut tercermin pada panggilan `GetEffective` berikutnya. Jika sumber pemformatan induk diubah atau dihapus, data efektif yang sebelumnya diperoleh mungkin sudah tidak up-to-date. Setelah `GetEffective` dipanggil lagi, Aspose.Slides akan mengevaluasi kembali pohon pemformatan dan font, warna, ukuran, atau nilai lain yang dihasilkan dapat berubah.

**Bisakah saya memodifikasi nilai melalui objek data efektif?**

Tidak. Objek data efektif hanya menampilkan nilai yang telah dihitung. Lakukan perubahan pada objek pemformatan lokal, kemudian peroleh kembali nilai efektif.

**Apa yang terjadi jika suatu properti tidak diatur pada tingkat bentuk, maupun pada tata letak/master, maupun pada pengaturan global?**

Nilai efektif ditentukan oleh mekanisme default, yang mencakup default PowerPoint dan Aspose.Slides. Nilai yang terpecahkan tersebut menjadi bagian dari data efektif saat ini.

**Dari nilai font efektif, dapatkah saya mengetahui level mana yang menyediakan ukuran atau jenis font?**

Tidak secara langsung. Data efektif mengembalikan nilai akhir. Untuk menemukan sumbernya, periksa nilai lokal pada bagian, paragraf, bingkai teks, dan gaya teks pada tata letak, master, serta tingkat presentasi untuk melihat di mana definisi eksplisit pertama muncul.

**Mengapa nilai efektif kadang tampak identik dengan nilai lokal?**

Karena nilai lokal berakhir menjadi nilai akhir (tidak diperlukan pewarisan pada tingkat yang lebih tinggi). Dalam kasus tersebut, nilai efektif sama dengan nilai lokal.

**Kapan saya harus menggunakan properti efektif, dan kapan saya harus bekerja hanya dengan yang lokal?**

Gunakan data efektif ketika Anda memerlukan hasil "seperti yang ditampilkan" setelah semua pewarisan diterapkan, seperti untuk menyelaraskan warna, indentasi, atau ukuran. Jika Anda perlu mempertahankan nilai tersebut terlepas dari perubahan pemformatan di kemudian hari, salin properti yang diperlukan ke dalam objek Anda sendiri. Jika Anda perlu mengubah pemformatan pada tingkat tertentu, ubah properti lokal dan kemudian, jika diperlukan, baca kembali data efektif untuk memverifikasi hasilnya.