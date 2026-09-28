---
title: Demo Kurulumu
type: docs
weight: 70
url: /tr/jasperreports/demos-setup/
description: "Aspose.Slides for JasperReports indirmesinden demo projelerini kurun, kullandıkları dışa aktarım sınıfını değiştirin ve Ant ile derleyin."
---
## **Denemeler Nedir**

*Aspose.Slides for JasperReports* indirmesinin *samples* klasörü sekiz demo projesi içerir: *charts*, *fonts*, *images*, *landscape*, *shapes*, *subreport*, *text* ve *xmldatasource*. Bunlar standart JasperReports demolarıdır, doldurulmuş raporu PPT’ye dışa aktaran bir `ppt` derleme hedefi eklemek için değiştirilmiştir. İndirme, dışa aktarılmış sunumlar içermez; bir demoyu derleyerek oluşturursunuz.

## **Derlemeden Önce Dışa Aktarım Sınıfını Değiştirin**

Varsayılan olarak, demoların Java kodu mevcut jar dosyalarının içinde bulunmayan `com.aspose.slides.jasperreports.JRPptExporter` sınıfını kullanır, bu yüzden demolar derlenmez. Demo uygulama sınıfında (örneğin *shapes* demodaki *ShapesApp.java*), `JRPptExporter` yerine aynı paketteki PPT dışa aktarımcısı `ASPptExporter`ı koyun. *fonts* demosu tüm paketi içe aktarır, bu yüzden yalnızca kod içindeki sınıf adı değişir.

Demolar ayrıca daha sonraki JasperReports sürümlerinde kaldırılan `JExcelApiExporter` ve `JRExporterParameter.FONT_MAP` gibi JasperReports sınıflarını da kullanır. Yukarıdaki değişiklikle demolar şu şekilde derlenir:

| JasperReports version | Derlenen Demolar |
| :- | :- |
| 5.5.1 | tüm sekiz |
| 5.5.2 and 6.4.0 | *charts*, *images*, *landscape*, *shapes* ve *xmldatasource* |
| 6.16.0 | *charts* |

## **Bir Demo Derleyin**

Her demonun *build.xml* dosyası bir JasperReports projesinin klasör yapısını bekler: *../../../build/classes* ve *../../../lib* altındaki jar dosyalarına göre derler, demo klasörüne görecelidir.

1. Demo klasörünü JasperReports projenizin *demo/samples* klasörüne kopyalayın.  
2. İndirmenin *lib* alt klasöründen JasperReports sürümünüzü kapsayan *aspose.slides.jasperreports.library-xx.x.jar* dosyasını JasperReports projesinin *lib* klasörüne kopyalayın. Bakınız [Installing Aspose.Slides for JasperReports](/slides/tr/jasperreports/installing-aspose-slides-for-jasperreports/).  
3. JasperReports sürümünüzün jar dosyasını ve ona bağımlı jar dosyalarını aynı *lib* klasörüne koyun. Demo dosyalarının yanında, *build.xml* yalnızca *build/classes* ve *lib* altındaki jar dosyalarını sınıf yoluna ekler; *build/classes* yalnızca JasperReports kaynak kodundan derlendikten sonra JasperReports sınıflarını tutar.  
4. *charts*, *subreport* ve *text* demoları JasperReports’un HSQLDB örnek veritabanını (`jdbc:hsqldb:hsql://localhost`) okur, bu yüzden indirmedeki *samples/Readme.txt* dosyasında anlatıldığı gibi önce sunucusunu başlatın. Diğer demolar veri tabanı gerektirmez.  
5. Demo klasöründe, uygulamayı derleyin, rapor tasarımını derleyin, doldurun ve PPT’ye dışa aktarın:

```bash
ant javac
ant compile
ant fill
ant ppt
```

`ppt` hedefi, doldurulmuş raporun yanına, rapor adını taşıyan bir sunum dosyası yazar (örneğin *LandscapeReport.ppt*).

İki demo yukarıdaki adımlardan daha fazlasını gerektirir:

- *images* demo, dışa aktarma sırasında `http://jasperreports.sourceforge.net/jasperreports.png` adresindeki bir resmi yükler. Bu adres artık HTTPS’ye yönlendirildiği için, *ImagesReport.jrxml* içinde adresi `https://` olarak değiştirene kadar `ppt` adımı bir sunum oluşturmaz. JasperReports 6.4.0 ile bu resmin dışa aktarımı HTTPS üzerinden bile başarısız olur.  
- *xmldatasource* raporu Arial yazı tipini kullanır. Sisteminizde Arial yoksa, `ant fill` yazı tipinin "JVM’e mevcut olmadığını" bildirir ve doldurulmuş rapor üretmez; bu yüzden `ant ppt` dışa aktaracak bir şey bulamaz. Derleme yine de başarı olarak raporlanır; her adımın çıktısını kontrol edin.