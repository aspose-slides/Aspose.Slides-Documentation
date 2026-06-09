---
title: C++ Kullanarak Sunum Grafiklerinde Hata Çubuklarını Özelleştirme
linktitle: Hata Çubuğu
type: docs
url: /tr/cpp/error-bar/
keywords:
- hata çubuğu
- özel değer
- PowerPoint
- sunum
- С++
- Aspose.Slides
description: "Aspose.Slides for С++ ile grafiklere hata çubuğu eklemeyi ve özelleştirmeyi öğrenin — PowerPoint sunumlarında veri görsellerini optimize edin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunum grafiklerinde hata çubuklarıyla nasıl çalışılacağını açıklar. Bir grafik serisine hata çubuğu eklemeyi, X ve Y hata çubuğu ayarlarını yapılandırmayı ve sabit, yüzde ve özel değerler gibi farklı değer türlerini uygulamayı gösterir. Ayrıca, ilgili veri nokta koleksiyonunu kullanarak bir serideki bireysel veri noktalarına özel hata çubuğu değerleri atamanın nasıl yapılacağını gösterir. Ayrıca, makalede hata çubuklarının dışa aktarma sırasında nasıl davrandığı, işaretçiler ve veri etiketleriyle uyumluluğu ve ilgili API referans sınıfları ve enumlarını nerede bulunabileceğiyle ilgili kısa notlar da yer alır.

## **Hata Çubukları Ekle**

Aspose.Slides for C++ hata çubuğu değerlerini yönetmek için basit bir API sağlar. Örnek kod, özel bir değer türü kullanıldığında uygulanır. Bir değeri belirtmek için, serinin **DataPoints** koleksiyonundaki belirli bir veri noktasının **ErrorBarCustomValues** özelliğini kullanın:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İstenen slayta bir balon grafiği ekleyin.
3. İlk grafik serisine erişin ve hata çubuğu X formatını ayarlayın.
4. İlk grafik serisine erişin ve hata çubuğu Y formatını ayarlayın.
5. Çubuk değerlerini ve formatını ayarlama.
6. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}

## **Özel Hata Çubukları Ekle**

Aspose.Slides for C++ özel hata çubuğu değerlerini yönetmek için basit bir API sağlar. Örnek kod, **IErrorBarsFormat.ValueType** özelliği **Custom** olduğunda uygulanır. Bir değeri belirtmek için, serinin **DataPoints** koleksiyonundaki belirli bir veri noktasının **ErrorBarCustomValues** özelliğini kullanın:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İstenen slayta bir balon grafiği ekleyin.
3. İlk grafik serisine erişin ve hata çubuğu X formatını ayarlayın.
4. İlk grafik serisine erişin ve hata çubuğu Y formatını ayarlayın.
5. Grafik serisinin bireysel veri noktalarına erişin ve belirli bir seri veri noktası için Hata Çubuğu değerlerini ayarlayın.
6. Çubuk değerlerini ve formatını ayarlama.
7. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}

## **SSS**

**Bir sunumu PDF veya görüntülere dışa aktarırken hata çubukları ne olur?**

Hata çubukları, grafiğin bir parçası olarak işlenir ve uyumlu bir sürüm veya renderlayıcı varsayılarak dönüşüm sırasında grafiğin geri kalan biçimlendirmesiyle birlikte korunur.

**Hata çubukları işaretçiler ve veri etiketleriyle birleştirilebilir mi?**

Evet. Hata çubukları ayrı bir öğedir ve işaretçiler ve veri etiketleriyle uyumludur; öğeler çakışırsa biçimlendirmeyi ayarlamanız gerekebilir.

**API'de hata çubuklarıyla çalışmak için özellikler ve enumların listesini nerede bulabilirim?**

API referansında: [ErrorBarsFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/errorbarsformat/) sınıfı ve ilgili enumlar [ErrorBarType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/errorbartype/) ve [ErrorBarValueType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/errorbarvaluetype/).