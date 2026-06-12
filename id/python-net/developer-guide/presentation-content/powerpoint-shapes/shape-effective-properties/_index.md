---
title: Dapatkan Properti Efektif Bentuk dari Presentasi dengan Python
linktitle: Properti Efektif
type: docs
weight: 50
url: /id/python-net/shape-effective-properties/
keywords:
- properti bentuk
- properti kamera
- rig cahaya
- bentuk bevel
- bingkai teks
- gaya teks
- tinggi font
- format isi
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Temukan cara Aspose.Slides untuk Python via .NET menghitung dan menerapkan properti bentuk efektif untuk rendering PowerPoint yang tepat."
---
## **Ikhtisar**

Topik ini menjelaskan perbedaan antara properti **lokal** dan **efektif**. Nilai lokal adalah nilai yang ditetapkan secara langsung pada tingkat pemformatan tertentu, seperti:

1. Properti bagian pada slide.  
1. Gaya teks bentuk prototipe pada tata letak atau slide master, ketika bentuk bingkai teks bagian memiliki satu.  
1. Pengaturan teks global dalam presentasi.

Nilai lokal dapat didefinisikan atau diabaikan pada setiap tingkat. Ketika Aspose.Slides membutuhkan pemformatan akhir "sebagai render", ia menyelesaikan rantai pewarisan dan mengembalikan nilai **efektif**. Anda dapat memperolehnya dengan memanggil metode `get_effective` pada objek format lokal.

Contoh berikut menunjukkan cara mendapatkan nilai efektif. Contoh ini mengasumsikan bahwa bentuk pertama pada slide pertama adalah sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) dengan bingkai teks dan setidaknya satu bagian.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    paragraph = shape.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    local_portion_format = portion.portion_format
    effective_portion_format = local_portion_format.get_effective()
```

{{% alert color="primary" %}}
Data pemformatan efektif mewakili pemformatan yang dihitung saat ini setelah pewarisan diterapkan. Dalam implementasi saat ini, beberapa objek data efektif, seperti [IPortionFormatEffectiveData](https://reference.aspose.com/slides/id/python-net/aspose.slides/iportionformateffectivedata/), dapat disimpan dalam cache secara internal. Memanggil `get_effective` lagi setelah mengubah pemformatan induk atau yang diwariskan dapat menyegarkan data cache, dan objek yang sebelumnya diperoleh mungkin tidak lagi mewakili keadaan sebelumnya. Jika Anda perlu menyimpan nilai efektif untuk penggunaan kembali di masa mendatang, salin properti yang diperlukan, seperti tinggi font, warna isi, gaya font, atau perataan, ke dalam objek data Anda sendiri.
{{% /alert %}}

## **Mendapatkan Properti Efektif Kamera**

Aspose.Slides memungkinkan Anda mendapatkan properti efektif dari kamera. Tipe [ICameraEffectiveData](https://reference.aspose.com/slides/id/python-net/aspose.slides/icameraeffectivedata/) mewakili objek tak dapat diubah yang berisi properti kamera efektif. Sebuah instance [ICameraEffectiveData](https://reference.aspose.com/slides/id/python-net/aspose.slides/icameraeffectivedata/) disajikan melalui [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/id/python-net/aspose.slides/ithreedformateffectivedata/), yang menyediakan nilai efektif untuk [ThreeDFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/).

Contoh kode berikut menunjukkan cara mendapatkan properti efektif untuk kamera. Contoh ini mengasumsikan bahwa bentuk pertama pada slide pertama memiliki pemformatan 3D.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    camera = three_d_effective_data.camera

    camera_type = camera.camera_type
    field_of_view_angle = camera.field_of_view_angle
    zoom = camera.zoom

    print("= Effective camera properties =")
    print("Type: " + str(camera_type))
    print("Field of view: " + str(field_of_view_angle))
    print("Zoom: " + str(zoom))
```

## **Mendapatkan Properti Efektif Rig Cahaya**

Aspose.Slides memungkinkan Anda mendapatkan properti efektif dari rig cahaya. Tipe [ILightRigEffectiveData](https://reference.aspose.com/slides/id/python-net/aspose.slides/ilightrigeffectivedata/) mewakili objek tak dapat diubah yang berisi properti rig cahaya efektif. Sebuah instance [ILightRigEffectiveData](https://reference.aspose.com/slides/id/python-net/aspose.slides/ilightrigeffectivedata/) disajikan melalui [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/id/python-net/aspose.slides/ithreedformateffectivedata/), yang menyediakan nilai efektif untuk [ThreeDFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/).

Contoh kode berikut menunjukkan cara mendapatkan properti efektif untuk rig cahaya. Contoh ini mengasumsikan bahwa bentuk pertama pada slide pertama memiliki pemformatan 3D.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    light_rig = three_d_effective_data.light_rig

    light_type = light_rig.light_type
    direction = light_rig.direction

    print("= Effective light rig properties =")
    print("Type: " + str(light_type))
    print("Direction: " + str(direction))
```

## **Mendapatkan Properti Efektif Bentuk Bevel**

Aspose.Slides memungkinkan Anda mendapatkan properti efektif dari bevel bentuk. Tipe [IShapeBevelEffectiveData](https://reference.aspose.com/slides/id/python-net/aspose.slides/ishapebeveleffectivedata/) mewakili objek tak dapat diubah yang berisi properti relief wajah efektif untuk sebuah bentuk. Sebuah instance [IShapeBevelEffectiveData](https://reference.aspose.com/slides/id/python-net/aspose.slides/ishapebeveleffectivedata/) disajikan melalui [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/id/python-net/aspose.slides/ithreedformateffectivedata/), yang menyediakan nilai efektif untuk [ThreeDFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/).

Contoh kode berikut menunjukkan cara mendapatkan properti efektif untuk bevel atas sebuah bentuk. Contoh ini mengasumsikan bahwa bentuk pertama pada slide pertama memiliki pemformatan 3D.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    top_bevel = three_d_effective_data.bevel_top

    bevel_type = top_bevel.bevel_type
    bevel_width = top_bevel.width
    bevel_height = top_bevel.height

    print("= Effective shape's top face relief properties =")
    print("Type: " + str(bevel_type))
    print("Width: " + str(bevel_width))
    print("Height: " + str(bevel_height))
```

## **Mendapatkan Properti Efektif Bingkai Teks**

Dengan Aspose.Slides, Anda dapat memperoleh properti efektif dari bingkai teks. Tipe [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/id/python-net/aspose.slides/itextframeformateffectivedata/) berisi properti pemformatan bingkai teks yang efektif.

Contoh kode berikut menunjukkan cara mendapatkan properti pemformatan bingkai teks yang efektif. Contoh ini mengasumsikan bahwa bentuk pertama pada slide pertama adalah sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) dengan bingkai teks.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = text_frame_format.get_effective()

    anchoring_type = effective_text_frame_format.anchoring_type
    autofit_type = effective_text_frame_format.autofit_type
    text_vertical_type = effective_text_frame_format.text_vertical_type
    margin_left = effective_text_frame_format.margin_left
    margin_top = effective_text_frame_format.margin_top
    margin_right = effective_text_frame_format.margin_right
    margin_bottom = effective_text_frame_format.margin_bottom

    print("Anchoring type: " + str(anchoring_type))
    print("Autofit type: " + str(autofit_type))
    print("Text vertical type: " + str(text_vertical_type))
    print("Margins")
    print("   Left: " + str(margin_left))
    print("   Top: " + str(margin_top))
    print("   Right: " + str(margin_right))
    print("   Bottom: " + str(margin_bottom))
```

## **Mendapatkan Properti Efektif Gaya Teks**

Dengan Aspose.Slides, Anda dapat memperoleh properti efektif dari gaya teks. Tipe [ITextStyleEffectiveData](https://reference.aspose.com/slides/id/python-net/aspose.slides/itextstyleeffectivedata/) berisi properti gaya teks yang efektif.

Contoh kode berikut menunjukkan cara mendapatkan properti gaya teks yang efektif. Contoh ini mengasumsikan bahwa bentuk pertama pada slide pertama adalah sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) dengan bingkai teks.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame_format = shape.text_frame.text_frame_format
    text_style = text_frame_format.text_style
    effective_text_style = text_style.get_effective()
    level_count = 9

    for level_index in range(level_count):
        effective_style_level = effective_text_style.get_level(level_index)
        depth = effective_style_level.depth
        indent = effective_style_level.indent
        alignment = effective_style_level.alignment
        font_alignment = effective_style_level.font_alignment

        print("= Effective paragraph formatting for style level #" + str(level_index) + " =")

        print("Depth: " + str(depth))
        print("Indent: " + str(indent))
        print("Alignment: " + str(alignment))
        print("Font alignment: " + str(font_alignment))
```

## **Mendapatkan Nilai Tinggi Font Efektif**

Dengan Aspose.Slides, Anda dapat memperoleh tinggi font yang efektif. Kode berikut menunjukkan bagaimana tinggi font efektif sebuah bagian berubah setelah nilai tinggi font lokal diatur pada berbagai tingkat struktur presentasi.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)
    auto_shape.add_text_frame("")

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    first_portion = slides.Portion("Sample text with first portion")
    second_portion = slides.Portion(" and second portion.")

    paragraph.portions.add(first_portion)
    paragraph.portions.add(second_portion)

    print("Effective font height just after creation:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    default_text_style_level = presentation.default_text_style.get_level(0)
    default_text_style_level.default_portion_format.font_height = 24

    print("Effective font height after setting the presentation default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Effective font height after setting paragraph default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    first_portion.portion_format.font_height = 55

    print("Effective font height after setting portion #0 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    second_portion.portion_format.font_height = 18

    print("Effective font height after setting portion #1 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    presentation.save("SetLocalFontHeightValues.pptx", slides.export.SaveFormat.PPTX)
```

## **Mendapatkan Format Isi Efektif untuk Tabel**

Dengan Aspose.Slides, Anda dapat memperoleh pemformatan isi yang efektif untuk berbagai bagian tabel. Tipe [IFillFormatEffectiveData](https://reference.aspose.com/slides/id/python-net/aspose.slides/ifillformateffectivedata/) berisi properti pemformatan isi yang efektif. Pemformatan sel memiliki prioritas lebih tinggi daripada pemformatan baris, pemformatan baris memiliki prioritas lebih tinggi daripada pemformatan kolom, dan pemformatan kolom memiliki prioritas lebih tinggi daripada pemformatan seluruh tabel.

Akibatnya, properti [ICellFormatEffectiveData](https://reference.aspose.com/slides/id/python-net/aspose.slides/icellformateffectivedata/) digunakan untuk menggambar sel tabel. Contoh kode berikut menunjukkan cara memperoleh pemformatan isi yang efektif untuk berbagai bagian tabel. Contoh ini mengasumsikan bahwa bentuk pertama pada slide pertama adalah sebuah [Table](https://reference.aspose.com/slides/id/python-net/aspose.slides/table/).

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    first_row = table.rows[0]
    first_column = table.columns[0]
    first_cell = first_row[0]

    table_format_effective = table.table_format.get_effective()
    row_format_effective = first_row.row_format.get_effective()
    column_format_effective = first_column.column_format.get_effective()
    cell_format_effective = first_cell.cell_format.get_effective()

    table_fill_format_effective = table_format_effective.fill_format
    row_fill_format_effective = row_format_effective.fill_format
    column_fill_format_effective = column_format_effective.fill_format
    cell_fill_format_effective = cell_format_effective.fill_format
```

## **FAQ**

**Apakah `get_effective` mengembalikan snapshot?**

Tidak selalu. Data efektif mewakili pemformatan yang dihitung setelah pewarisan diterapkan, tetapi beberapa objek data efektif dapat disimpan dalam cache secara internal. Panggilan `get_effective` berikutnya mungkin menghitung ulang pemformatan dan menyegarkan data cache, sehingga objek yang sebelumnya diperoleh tidak boleh dianggap sebagai snapshot yang tahan lama.

**Kapan saya harus membaca kembali properti efektif?**

Panggil `get_effective` lagi setelah mengubah pemformatan lokal, gaya induk, pemformatan tata letak, pemformatan master, atau nilai default pada level presentasi. Panggilan berikutnya akan mengevaluasi kembali hierarki pemformatan dan mengembalikan hasil efektif saat ini.

**Apakah mengubah atau menghapus slide tata letak/master memengaruhi properti efektif yang sudah diambil?**

Ya, tetapi perubahan tersebut tercermin pada panggilan `get_effective` berikutnya. Jika sumber pemformatan induk diubah atau dihapus, data efektif yang sebelumnya diperoleh mungkin sudah usang. Setelah `get_effective` dipanggil lagi, Aspose.Slides akan mengevaluasi kembali pohon pemformatan dan font, warna, ukuran, atau nilai lainnya yang dihasilkan dapat berubah.

**Dapatkah saya mengubah nilai melalui objek data efektif?**

Tidak. Objek data efektif hanya menampilkan nilai yang dihitung. Lakukan perubahan pada objek pemformatan lokal, kemudian peroleh kembali nilai efektif.

**Apa yang terjadi jika sebuah properti tidak diatur pada tingkat bentuk, maupun pada tata letak/master, maupun pada pengaturan global?**

Nilai efektif ditentukan oleh mekanisme default, yang mencakup nilai default PowerPoint dan Aspose.Slides. Nilai yang terpecahkan itu menjadi bagian dari data efektif saat ini.

**Dari nilai font efektif, dapatkah saya mengetahui level mana yang menyediakan ukuran atau jenis huruf?**

Tidak secara langsung. Data efektif mengembalikan nilai akhir. Untuk menemukan sumbernya, periksa nilai lokal pada bagian, paragraf, bingkai teks, dan gaya teks pada tata letak, master, serta tingkat presentasi untuk melihat di mana definisi eksplisit pertama muncul.

**Mengapa nilai efektif kadang-kadang terlihat identik dengan nilai lokal?**

Karena nilai lokal berakhir menjadi nilai akhir (tidak diperlukan pewarisan dari tingkat lebih tinggi). Dalam kasus tersebut, nilai efektif cocok dengan nilai lokal.

**Kapan saya harus menggunakan properti efektif, dan kapan saya harus bekerja hanya dengan properti lokal?**

Gunakan data efektif ketika Anda memerlukan hasil "sebagai render" setelah semua pewarisan diterapkan, seperti menyelaraskan warna, indentasi, atau ukuran. Jika Anda perlu mempertahankan nilai tersebut terlepas dari perubahan pemformatan nantinya, salin properti yang diperlukan ke dalam objek Anda sendiri. Jika Anda perlu mengubah pemformatan pada tingkat tertentu, modifikasi properti lokal dan kemudian, bila perlu, baca kembali data efektif untuk memverifikasi hasilnya.