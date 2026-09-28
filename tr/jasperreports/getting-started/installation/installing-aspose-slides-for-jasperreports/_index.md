---
title: Aspose.Slides for JasperReports kurulumu
type: docs
weight: 40
url: /tr/jasperreports/installing-aspose-slides-for-jasperreports/
description: "JasperReports sürümünüzle eşleşen Aspose.Slides for JasperReports jar dosyalarını seçin ve bunları JasperReports'a, bir Maven projesine veya JasperReports Server'a ekleyin."
---
## **JasperReports sürümünüz için jar dosyalarını seçin**

Aspose.Slides for JasperReports, [download page](https://releases.aspose.com/slides/tr/jasperreport/) adresinde bir ZIP dosyası olarak dağıtılır. *lib* klasörü, JasperReports sürüm aralıkları başına bir alt klasöre sahiptir. Kullandığınız JasperReports sürümünü kapsayan alt klasörden jar dosyalarını alın:

| JasperReports sürümü | *lib* alt klasörü |
| :- | :- |
| 3.7.2 to 5.5.1 | *JasperReports 3.7.2 - 5.5.1 (JDK 1.6)* |
| 5.5.2 to 6.4.0 | *JasperReports 5.5.2 - 6.4.0 (JDK 1.6)* |
| 6.5.0 to 6.16.0 | *JasperReports 6.5.0 - 6.16.0 (JDK 1.6)* |

JasperReports 6.17.0 ve sonrasını, JasperReports 7 dahil, kapsayan bir alt klasör yoktur. *JasperReports 2.0.3 - 3.7.1 (JDK 1.4)* alt klasörü hiçbir jar içermez, yalnızca bu sürümlere olan desteğin Aspose.Slides for JasperReports 17.6 ile sona erdiğine dair bir not bulunur.

Her alt klasör iki jar dosyası içerir; adlarında bulunan *xx.x* ürün sürümünü gösterir:

- *aspose.slides.jasperreports.library-xx.x.jar* JasperReports Library (`ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` ve `ASHtmlExporter`) için dışa aktarıcıları ve `License` sınıfını içerir.
- *aspose.slides.jasperreports.server-xx.x.jar* JasperReports Server için dışa aktarma eylemlerini içerir. Kütüphane jar'ına dayanır, bu yüzden sunucu her zaman aynı alt klasörden iki jar'ı da gerektirir.

## **Kütüphane jar'ını JasperReports'a veya uygulamanıza ekleyin**

*aspose.slides.jasperreports.library-xx.x.jar* dosyasını eşleşen alt klasörden JasperReports'un *lib* klasörüne veya uygulamanızın sınıf yoluna kopyalayın. Uygulamanız daha sonra kod içinde dışa aktarıcıları oluşturabilir.

{{% alert color="info" title="Note" %}}
Linux'ta JasperReports, bir raporu doldurmak için fontconfig ve en az bir yüklü fonta ihtiyaç duyar. Fontlar olmadan, doldurma işlemi "Error initializing graphic environment" hatasıyla başarısız olur.
{{% /alert %}}

## **Kütüphane jar'ını bir Maven projesine ekleyin**

Jar, Maven deposu yerine ZIP içinde gelir. Maven derlemesinde kullanmak için yerel Maven deponuza kurmanız gerekir. 26.6 sürümü için, jar dosyasının bulunduğu klasörde şu komutu çalıştırın:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

Ardından, *pom.xml* içinde bağımlılıklara, jar'ın alt klasörünün kapsadığı bir JasperReports sürümüyle birlikte ekleyin:

```xml
<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides-jasperreports</artifactId>
    <version>26.6</version>
</dependency>
```

Grup ve artifact kimlikleri, kurulum komutunda seçtiğiniz değerlerdir; sadece eşleşmeleri gerekir. JasperReports 6.16.0 kullanan tam bir proje, [Your first export](/slides/tr/jasperreports/#your-first-export) sayfasındadır.

## **Jar dosyalarını JasperReports Server'a ekleyin**

Her iki jar'ı da eşleşen alt klasörden JasperReports Server web uygulamasının *WEB-INF/lib* klasörüne kopyalayın, ardından dışa aktarıcıları [Integration with JasperServer](/slides/tr/jasperreports/integration-with-jasperserver/) sayfasında açıklandığı gibi kaydedin.