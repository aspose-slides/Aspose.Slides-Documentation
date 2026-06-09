---
title: Python ile Sunumlardan Şekil Etkili Özelliklerini Alın
linktitle: Etkili Özellikler
type: docs
weight: 50
url: /tr/python-net/shape-effective-properties/
keywords:
- şekil özellikleri
- kamera özellikleri
- ışık sistemi
- kavisli şekil
- metin çerçevesi
- metin stili
- yazı tipi yüksekliği
- dolgu biçimi
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET'in etkili şekil özelliklerini nasıl hesapladığını ve uyguladığını keşfedin, böylece PowerPoint sunumları hassas bir şekilde render edilir."
---
## **Genel Bakış**

Bu konu **local** ve **effective** özellikler arasındaki farkı açıklar. Local değerler, belirli bir biçimlendirme seviyesinde doğrudan ayarlanan değerlerdir, örnek olarak:

1. Slayttaki bölüm özellikleri.
2. Bir düzen veya ana slaytta prototip şekil metin stilleri, bölümün metin çerçevesi şekli bir stile sahip olduğunda.
3. Sunumdaki küresel metin ayarları.

Local değerler herhangi bir seviyede tanımlanabilir veya atlanabilir. Aspose.Slides, son “görüntülendiği gibi” biçimlendirmeye ihtiyacı olduğunda, kalıtım zincirini çözer ve **effective** değerleri döndürür. Bunları, yerel format nesnesi üzerinde `get_effective` yöntemini çağırarak alabilirsiniz.

Aşağıdaki örnek, effective değerleri nasıl alacağınızı gösterir. İlk slayttaki ilk şeklin bir metin çerçevesi ve en az bir bölüm içeren bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) olduğunu varsayar.

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
Effective biçimlendirme verisi, kalıtım uygulandıktan sonra hesaplanan mevcut biçimlendirmeyi temsil eder. Mevcut uygulamada, [IPortionFormatEffectiveData](https://reference.aspose.com/slides/tr/python-net/aspose.slides/iportionformateffectivedata/) gibi bazı effective veri nesneleri dahili olarak önbelleğe alınabilir. Üst veya kalıtsal biçimlendirme değiştirildikten sonra `get_effective` metodunu tekrar çağırmak önbellek verisini yenileyebilir ve daha önce elde edilen nesne artık önceki durumu yansıtmayabilir. Effective değerleri daha sonraki kullanım için korumanız gerekiyorsa, yazı tipi yüksekliği, doldurma rengi, yazı tipi stili veya hizalama gibi gerekli özellikleri kendi veri nesnenize kopyalayın.
{{% /alert %}}

## **Kamera'nın Effective Özelliklerini Almak**

Aspose.Slides, bir kameranın effective özelliklerini almanıza olanak tanır. [ICameraEffectiveData](https://reference.aspose.com/slides/tr/python-net/aspose.slides/icameraeffectivedata/) türü, effective kamera özelliklerini içeren değiştirilemez bir nesneyi temsil eder. Bir [ICameraEffectiveData](https://reference.aspose.com/slides/tr/python-net/aspose.slides/icameraeffectivedata/) örneği, [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ithreedformateffectivedata/) aracılığıyla sunulur ve bu, [ThreeDFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/) için effective değerler sağlar.

Aşağıdaki kod örneği, kamera için effective özelliklerin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin 3D biçimlendirmeye sahip olduğunu varsayar.

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

## **Light Rig'in Effective Özelliklerini Almak**

Aspose.Slides, bir ışık sisteminin effective özelliklerini almanıza olanak tanır. [ILightRigEffectiveData](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ilightrigeffectivedata/) türü, effective ışık sistemi özelliklerini içeren değiştirilemez bir nesnedir. Bir [ILightRigEffectiveData](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ilightrigeffectivedata/) örneği, [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ithreedformateffectivedata/) aracılığıyla sunulur ve bu, [ThreeDFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/) için effective değerler sağlar.

Aşağıdaki kod örneği, ışık sisteminin effective özelliklerinin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin 3D biçimlendirmeye sahip olduğunu varsayar.

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

## **Bevel Şeklinin Effective Özelliklerini Almak**

Aspose.Slides, bir şekil köşesinin (bevel) effective özelliklerini almanıza olanak tanır. [IShapeBevelEffectiveData](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ishapebeveleffectivedata/) türü, bir şeklin effective yüzey rahatlatma (face‑relief) özelliklerini içeren değiştirilemez bir nesnedir. Bir [IShapeBevelEffectiveData](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ishapebeveleffectivedata/) örneği, [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ithreedformateffectivedata/) aracılığıyla sunulur ve bu, [ThreeDFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/) için effective değerler sağlar.

Aşağıdaki kod örneği, bir şeklin üst köşesinin effective özelliklerini nasıl alacağınızı gösterir. İlk slayttaki ilk şeklin 3D biçimlendirmeye sahip olduğunu varsayar.

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

## **Metin Çerçevesinin Effective Özelliklerini Almak**

Aspose.Slides kullanarak bir metin çerçevesinin effective özelliklerini alabilirsiniz. [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/tr/python-net/aspose.slides/itextframeformateffectivedata/) türü, effective metin çerçevesi biçimlendirme özelliklerini içerir.

Aşağıdaki kod örneği, metin çerçevesinin effective biçimlendirme özelliklerini nasıl alacağınızı gösterir. İlk slayttaki ilk şeklin bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) olduğunu ve bir metin çerçevesi içerdiğini varsayar.

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

## **Metin Stili'nin Effective Özelliklerini Almak**

Aspose.Slides kullanarak bir metin stilinin effective özelliklerini alabilirsiniz. [ITextStyleEffectiveData](https://reference.aspose.com/slides/tr/python-net/aspose.slides/itextstyleeffectivedata/) türü, effective metin stili özelliklerini içerir.

Aşağıdaki kod örneği, metin stilinin effective özelliklerini nasıl alacağınızı gösterir. İlk slayttaki ilk şeklin bir [AutoShape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshape/) olduğunu ve bir metin çerçevesi içerdiğini varsayar.

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

## **Effective Yazı Tipi Yüksekliği Değerini Almak**

Aspose.Slides kullanarak effective yazı tipi yüksekliğini alabilirsiniz. Aşağıdaki kod, bir bölümün effective yazı tipi yüksekliğinin, farklı sunum yapısı seviyelerinde yerel yazı tipi yüksekliği değerleri ayarlandıktan sonra nasıl değiştiğini gösterir.

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

## **Tablo İçin Effective Doldurma Biçimini Almak**

Aspose.Slides kullanarak farklı tablo bölümleri için effective doldurma biçimlendirmesini alabilirsiniz. [IFillFormatEffectiveData](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ifillformateffectivedata/) türü, effective doldurma biçimlendirme özelliklerini içerir. Hücre biçimlendirmesi, satır biçimlendirmesinden daha yüksek önceliğe sahiptir; satır biçimlendirmesi, sütun biçimlendirmesinden daha yüksek önceliğe sahiptir; sütun biçimlendirmesi ise tüm tablo biçimlendirmesinden daha yüksek önceliğe sahiptir.

Sonuç olarak, [ICellFormatEffectiveData](https://reference.aspose.com/slides/tr/python-net/aspose.slides/icellformateffectivedata/) özellikleri tablo hücresini çizerken kullanılır. Aşağıdaki kod örneği, farklı tablo bölümleri için effective doldurma biçimlendirmesinin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir [Table](https://reference.aspose.com/slides/tr/python-net/aspose.slides/table/) olduğunu varsayar.

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

**`get_effective` bir anlık görüntü döndürür mü?**

Her zaman değil. Effective veri, kalıtım uygulandıktan sonra hesaplanan biçimlendirmeyi temsil eder, ancak bazı effective veri nesneleri dahili olarak önbelleğe alınabilir. Sonraki bir `get_effective` çağrısı biçimlendirmeyi yeniden hesaplayabilir ve önbellek verisini yenileyebilir; bu nedenle daha önce elde edilen nesne dayanıklı bir anlık görüntü olarak ele alınmamalıdır.

**Effective özellikleri ne zaman tekrar okumalıyım?**

Yerel biçimlendirme, üst stil, düzen biçimlendirmesi, ana biçimlendirme veya sunum düzeyindeki varsayılanlar değiştirildikten sonra `get_effective`'i tekrar çağırın. Sonraki çağrı biçimlendirme hiyerarşisini yeniden değerlendirir ve mevcut effective sonucu döndürür.

**Bir düzen/ana slaytı değiştirmek veya kaldırmak, önceden alınmış effective özellikleri etkiler mi?**

Evet, ancak değişiklik bir sonraki `get_effective` çağrısında yansır. Bir üst biçimlendirme kaynağı değiştirildiğinde veya kaldırıldığında, daha önce elde edilen effective veri eski olabilir. `get_effective` tekrar çağrıldığında Aspose.Slides biçimlendirme ağacını yeniden değerlendirir ve elde edilen yazı tipleri, renkler, boyutlar veya diğer değerler değişebilir.

**Effective veri nesneleri üzerinden değerleri değiştirebilir miyim?**

Hayır. Effective veri nesneleri hesaplanmış değerleri sunar. Değişiklikleri yerel biçimlendirme nesnelerinde yapın ve ardından effective değerleri tekrar alın.

**Bir özellik şekil düzeyinde, düzen/ana slaytta ya da küresel ayarlarda ayarlanmamışsa ne olur?**

Effective değer, PowerPoint ve Aspose.Slides varsayılanlarını içeren varsayılan mekanizma tarafından belirlenir. Bu çözülen değer, mevcut effective verinin bir parçası haline gelir.

**Effective bir yazı tipi değerinden, boyutu ya da tipografiyi hangi seviyenin sağladığını anlayabilir miyim?**

Doğrudan değil. Effective veri son değeri döndürür. Kaynağı bulmak için bölüm, paragraf, metin çerçevesi ve düzen, ana ve sunum seviyelerindeki metin stillerindeki yerel değerleri kontrol edin; ilk açık tanımın hangi seviyede olduğunu görebilirsiniz.

**Effective değerler bazen yerel değerlerle aynı görünür, neden?**

Çünkü yerel değer nihai değer haline gelmiştir (daha yüksek seviyeden bir kalıtım gerekmemiştir). Bu durumda effective değer, yerel değerle aynı olur.

**Effective özellikleri ne zaman kullanmalıyım, ne zaman sadece yerel olanlarla çalışmalıyım?**

Tüm kalıtım uygulandıktan sonra “görüntülendiği gibi” sonucu elde etmeniz gerektiğinde effective veriyi kullanın; örneğin renkleri, girintileri veya boyutları hizalamak için. Bu değerleri daha sonraki biçimlendirme değişikliklerinden bağımsız olarak korumanız gerekiyorsa, gerekli özellikleri kendi nesnenize kopyalayın. Belirli bir seviyede biçimlendirme değiştirmek istiyorsanız, yerel özellikleri değiştirin ve gerektiğinde sonucu doğrulamak için effective veriyi tekrar okuyun.