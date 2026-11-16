---
title: Python'da Sunum Görünüm Özelliklerini Al ve Güncelle
linktitle: Görünüm Özellikleri
type: docs
weight: 80
url: /tr/python-net/presentation-view-properties/
keywords:
- görünüm özellikleri
- normal görünüm
- kontur içeriği
- kontur simgeleri
- dikey ayırıcıyı yakala
- tek görünüm
- çubuk durumu
- boyut boyutu
- otomatik ayar
- varsayılan yakınlaştırma
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint sunumlarında normal görünüm düzenini, slayt ve not yakınlaştırmasını, ızgara aralığını ve yorum görünürlüğünü yapılandırın."
---
## **Giriş**

PowerPoint'in normal görünümünde, slayt, küçük resimler veya bir kontur için yan panel ile alttaki notlar paneli arasında görünür. Aspose.Slides for Python via .NET, sunumun kaydedilmiş düzenleme tercihlerine [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) aracılığıyla erişim sağlar. Bunlar panel düzeni, yakınlaştırma seviyeleri, ızgara aralığı ve yorum görünürlüğünü içerir.

## **NormalViewProperties Hakkında**

[normal_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/) kullanarak [NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/) nesnesine erişin. [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) slayt başlıklarının yanındaki simgelerin görünmesini kontrol eder. [snap_vertical_splitter](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/snap_vertical_splitter/) kullanıcı yan paneli daralttığında panelin küçültülmüş durumuna yapışmasını sağlar. [prefer_single_view](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/prefer_single_view/) tam pencerede tek bir panelin görüntülenmesi tercihini gösterir.

[vertical_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/vertical_bar_state/) yan panel ile slayt arasındaki ayırıcıyı kontrol eder. [horizontal_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/horizontal_bar_state/) notlar panelinin üzerindeki ayırıcıyı kontrol eder. Her ikisi de `MINIMIZED`, `MAXIMIZED` veya `RESTORED` değerlerinden birini alan [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) değerini kabul eder.

<!-- visual-explanation:presentation-view-properties:start -->
[![Kavramsal bir düzenleyici, etiketli dikey ve yatay ayırıcılarla yan paneli, slayt bölgesini ve alt bölgeyi ayırır.](visual-presentation-view-properties-40ae1765a743.svg)](visual-presentation-view-properties-40ae1765a743.svg)

*Normal görünümde, dikey ayırıcı yan panelin genişliğini kontrol eder. Yatay ayırıcı notlar panelinin üzerindeki boşluğu kontrol eder.*
<!-- visual-explanation:presentation-view-properties:end -->

## **NormalViewProperties Geri Yükleme Hakkında**

Bir ayırıcı geri yüklendiğinde, [restored_left](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_left/) yan panelin kaydedilmiş boyutunu, [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) ise üst slayt alanının kaydedilmiş boyutunu sağlar. Her ikisi de [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/) nesnesini ortaya çıkarır. Bu nesnenin [dimension_size](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/dimension_size/) özelliği %0 ile %100 arasında bir yüzde alır ve [auto_adjust](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/auto_adjust/) pencere yeniden boyutlandırıldığında düzenleyicinin boyutu ayarlayıp ayarlamayacağını kontrol eder.

Bu örnek mevcut bir sunumu günceller. Yatay ayırıcıyı geri yükler, [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) değerini %80 olarak ayarlar ve otomatik ayarlamayı etkinleştirir, ayrıca dikey ayırıcıyı maksimum yapar. Ayrıca kontur görünümü için [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) etkinleştirilir.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    normal_view = presentation.view_properties.normal_view_properties
    normal_view.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    normal_view.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED
    normal_view.restored_top.auto_adjust = True
    normal_view.restored_top.dimension_size = 80
    normal_view.show_outline_icons = True

    presentation.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Varsayılan Yakınlaştırma Değerini Ayarlama**

[slide_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/) ve [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/notes_view_properties/) düzenleyici için bağımsız yakınlaştırma ayarlarını depolar. Bu ayarlar slayt boyutlarını, slayt gösterisi oynatımını veya görüntü dışa aktarma çözünürlüğünü etkilemez.

Bu örnek mevcut bir sunumu açar ve slaytı düzenleme penceresine uyacak şekilde ayarlamak için [variable_scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/variable_scale/) etkinleştirir. Not sayfası için otomatik ölçeklendirmeyi devre dışı bırakır ve [scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/scale/) değerini sabit %80 yakınlaştırmaya ayarlar.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    view_properties.slide_view_properties.variable_scale = True
    view_properties.notes_view_properties.variable_scale = False
    view_properties.notes_view_properties.scale = 80

    presentation.save("zoom.pptx", slides.export.SaveFormat.PPTX)
```

## **Izgara Aralığını Ayarlama**

[grid_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/grid_spacing/) sunum boyunca düzenleme ızgara çizgileri arasındaki mesafeyi ayarlar. Pozitif bir değer alır ve bir inçte 72 puan vardır. Bu örnek mevcut bir sunumdaki mevcut aralığı yazdırır ve aralığı 18 puana ayarlayarak çeyrek inçlik bir ızgara kaydeder.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current grid spacing: {view_properties.grid_spacing} points")

    view_properties.grid_spacing = 18.0

    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

Izgara sabit bir aralıkta tekrar eder. [Çizim kılavuzları](/slides/tr/python-net/drawing-guides/) tek tek yatay veya dikey konumları işaretler. Her ikisi de düzenleme yardımcılarıdır ve yalnızca bunları gösteren düzenleyicilerde görünür. Slayt gösterileri ve PDF, görseller ya da SVG dışa aktarmaları bunları içermez.

## **Sunum Açılırken Yorumları Göster veya Gizle**

[show_comments](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/show_comments/) uyumlu düzenleyicilerin sunumu açarken kullandığı bir tercihi depolar. Yorumlu mevcut bir sunum için bu örnek mevcut ayarı yazdırır ve yorumları gizli bir kopya kaydeder. Ayrıca [last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/last_view/) değerini [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/) olarak ayarlar, böylece kopya slayt görünümünde açılır.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current comment visibility: {view_properties.show_comments}")

    view_properties.show_comments = slides.NullableBool.FALSE
    view_properties.last_view = slides.ViewType.SLIDE_VIEW
    
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

Yorumları gizlemek, metinlerini, yazarlarını, konumlarını, yanıtlarını ve durumlarını korur. Yorumları kendilerini değiştirmek için [Sunum Yorumları](/slides/tr/python-net/presentation-comments/) bölümüne bakın. Dışa aktarma ayarları, yorumların PDF, HTML, görseller, notlar veya el ilanlarında görünüp görünmeyeceğini kontrol eder.

## **SSS**

**Sunumu tekrar açtığımda ızgara neden gizleniyor?**  
Sunum ızgara aralığını depolar. Izgarayı görmek için düzenleyicide ızgara görünürlüğünü etkinleştirin.

**Çizim kılavuzlarını temizlemek ızgara aralığını değiştirir mi?**  
Hayır. Bir kılavuzu eklemek, taşımak veya temizlemek ızgara aralığını değiştirmez.

**Bir sunumun farklı bölümleri farklı görünüm ayarlarına sahip olabilir mi?**  
Hayır. [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) tüm sunuma uygulanır.

**Farklı kullanıcılar için farklı görünüm ayarları kaydedebilir miyim?**  
Dosya herkes için tek bir görünüm özelliği seti depolar. Bir düzenleyici ayrıca kullanıcının yerel tercihlerine uygulayabilir.

**Bir şablonda görünüm ayarlarını kaydedebilir miyim?**  
Evet. Şablondan oluşturulan sunumlar, kaydedilmiş görünüm ayarlarını devralır.