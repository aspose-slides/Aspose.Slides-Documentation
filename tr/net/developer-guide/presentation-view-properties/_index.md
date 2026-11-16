---
title: ".NET'te Sunum Görünüm Özelliklerini Alın ve Güncelleyin"
linktitle: "Görünüm Özellikleri"
type: docs
weight: 80
url: /tr/net/presentation-view-properties/
keywords:
- görüntü özellikleri
- normal görünüm
- taslak içeriği
- taslak simgeleri
- dikey bölücüyü yakala
- tek görünüm
- çubuk durumu
- boyut ölçüsü
- otomatik ayarlama
- varsayılan yakınlaştırma
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'i kullanarak PowerPoint sunumlarında normal görünüm düzenini, slayt ve not yakınlaştırmasını, ızgara aralığını ve yorum görünürlüğünü yapılandırın."
---
## **Giriş**

PowerPoint'in normal görünümünde, slayt, küçük resimler veya taslak için yan bölme ile altında bir not bölmesi arasında görünür. Aspose.Slides for .NET, sunumun kaydedilmiş düzenleme tercihlerini [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) aracılığıyla ortaya çıkarır. Bunlar yan bölme düzeni, yakınlaştırma seviyeleri, ızgara aralığı ve yorum görünürlüğünü içerir.

## **INormalViewProperties Hakkında**

[NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/normalviewproperties/) kullanarak [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/) arabirimine erişin. [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) taslakta slayt başlıklarının yanına simgelerin görünmesini kontrol eder. [SnapVerticalSplitter](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/snapverticalsplitter/) kullanıcı yan bölmeyi daralttığında yan bölmenin küçültülmüş durumuna yapışmasını sağlar. [PreferSingleView](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/prefersingleview/) tam pencerede tek bir bölmenin görüntülenmesi tercihini belirtir.

[VerticalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/verticalbarstate/) yan bölme ile slayt arasındaki ayırıcıyı kontrol eder. [HorizontalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/horizontalbarstate/) not bölmesinin üzerindeki ayırıcıyı kontrol eder. İkisi de `Minimized`, `Maximized` veya `Restored` değerlerinden birini kabul eden bir [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype/) alır.

## **INormalViewProperties Geri Yükleme Hakkında**

Bir ayırıcı geri yüklendiğinde, [RestoredLeft](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredleft/) yan bölmenin kaydedilmiş boyutunu, [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) ise üst slayt alanının kaydedilmiş boyutunu sağlar. İkisi de [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/) arayüzünü ortaya çıkarır. Bu arayüzün [DimensionSize](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/dimensionsize/) özelliği 0‑100 arasında bir yüzde alır ve [AutoAdjust](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/autoadjust/) pencere yeniden boyutlandırıldığında düzenleyicinin boyutu ayarlayıp ayarlamayacağını kontrol eder.

Bu örnek mevcut bir sunumu günceller. Yatay ayırıcıyı geri yükler, [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) değerini %80 olarak ayarlar ve otomatik ayarlamayı etkinleştirir, ayrıca dikey ayırıcıyı büyütür. Taslak görünümü için [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) özelliğini de etkinleştirir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var normalView = presentation.ViewProperties.NormalViewProperties;
normalView.HorizontalBarState = SplitterBarStateType.Restored;
normalView.VerticalBarState = SplitterBarStateType.Maximized;
normalView.RestoredTop.AutoAdjust = true;
normalView.RestoredTop.DimensionSize = 80;
normalView.ShowOutlineIcons = true;

presentation.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
```

## **Varsayılan Yakınlaştırma Değerini Ayarla**

[SlideViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/slideviewproperties/) ve [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/notesviewproperties/) düzenleyici için bağımsız yakınlaştırma ayarları tutar. Bu ayarlar slayt boyutlarını, slayt gösterisi oynatımını veya görüntü dışa aktarma çözünürlüğünü etkilemez.

Bu örnek mevcut bir sunumu açar ve slaytı düzenleme penceresine sığdırmak için [VariableScale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/variablescale/) özelliğini etkinleştirir. Not sayfası için otomatik ölçeklemeyi devre dışı bırakır ve [Scale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/scale/) değerini sabit %80 yakınlaştırmaya ayarlar.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
viewProperties.SlideViewProperties.VariableScale = true;
viewProperties.NotesViewProperties.VariableScale = false;
viewProperties.NotesViewProperties.Scale = 80;

presentation.Save("zoom.pptx", SaveFormat.Pptx);
```

## **Izgara Aralığını Ayarla**

[GridSpacing](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/gridspacing/) sunum boyunca düzenleme ızgara çizgileri arasındaki mesafeyi ayarlar. Pozitif bir nokta değeri alır; bir inçte 72 nokta bulunur. Bu örnek mevcut bir sunumdaki mevcut aralığı yazdırır ve aralığı 18 noktaya ayarlayarak çeyrek inçlik bir ızgara kaydeder.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current grid spacing: {viewProperties.GridSpacing} points");

viewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

Izgara sabit bir aralıkta tekrar eder. [Drawing guides](/slides/tr/net/drawing-guides/) bireysel yatay veya dikey konumları işaretler. İkisi de düzenleme yardımcılarıdır ve yalnızca bunları gösteren düzenleyicilerde görünür. Slayt gösterileri ve PDF, görüntü veya SVG dışa aktarmaları bunları içermez.

## **Sunumu Açarken Yorumları Göster veya Gizle**

[ShowComments](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/showcomments/) uyumlu düzenleyicilerin sunumu açarken kullandığı bir tercih saklar. Yorumları içeren mevcut bir sunum için bu örnek mevcut ayarı yazdırır ve yorumları gizlenmiş bir kopya kaydeder. Ayrıca [LastView](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/lastview/) değerini [ViewType.SlideView](https://reference.aspose.com/slides/net/aspose.slides/viewtype/) olarak ayarlar, böylece kopya slayt görünümünde açılır.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current comment visibility: {viewProperties.ShowComments}");

viewProperties.ShowComments = NullableBool.False;
viewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

Yorumları gizlemek metinlerini, yazarlarını, konumlarını, yanıtlarını ve durumlarını korur. Yorumların kendisini değiştirmek için [Presentation Comments](/slides/tr/net/presentation-comments/) sayfasına bakın. Dışa aktarma ayarları yorumların PDF, HTML, görüntüler, notlar veya el ilanlarında görünüp görünmeyeceğini kontrol eder.

## **SSS**

**Sunumu yeniden açtığımda ızgara neden gizleniyor?**  
Sunum ızgara aralığını depolar. Izgarayı görmek için düzenleyicide ızgara görünürlüğünü etkinleştirin.

**Çizim kılavuzlarını temizlemek ızgara aralığını değiştirir mi?**  
Hayır. Bir kılavuz eklemek, taşımak veya temizlemek ızgara aralığını değiştirmez.

**Sunumun farklı bölümleri farklı görünüm ayarlarına sahip olabilir mi?**  
Hayır. [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) tüm sunuma uygulanır.

**Farklı kullanıcılar için farklı görünüm ayarları kaydedebilir miyim?**  
Dosya herkes için tek bir görünüm özelliği kümesi saklar. Bir düzenleyici ayrıca kullanıcının yerel tercihlerini uygulayabilir.

**Bir şablonda görünüm ayarlarını kaydedebilir miyim?**  
Evet. Şablondan oluşturulan sunumlar, kaydedilmiş görünüm ayarlarını devralır.