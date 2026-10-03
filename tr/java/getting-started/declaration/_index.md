---
title: Güvenlik Yöneticisi Gereksinimleri
type: docs
weight: 190
url: /tr/java/declaration/
keywords:
- Güvenlik Yöneticisi
- güvenlik politikası
- AllPermission
- izinler
- sandbox
- JDK 24
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Java 23 ve öncesinde Aspose.Slides for Java ile onu çağıran kodun ihtiyaç duyduğu Güvenlik Yöneticisi izinleri nelerdir ve Java 24 ve sonrasında yapılandırılacak bir şeyin olmamasının nedeni nedir."
---
## **Genel Bakış**

Java Güvenlik Yöneticisi, güvenlik politikasına göre kodun ne yapabileceğini sınırlar. Java 17, kaldırılması için kullanım dışı bıraktı ([JEP 411](https://openjdk.org/jeps/411)), ve Java 24 kalıcı olarak devre dışı bıraktı ([JEP 486](https://openjdk.org/jeps/486)). Bu makale, bir uygulama hâlâ Güvenlik Yöneticisi ile çalıştığında Aspose.Slides for Java'ın neye ihtiyaç duyduğunu açıklar. Uygulamanız birini etkinleştirmiyorsa (varsayılan budur), yapılandırılacak bir şey yoktur.

## **Java 23 ve Öncesi**

Bir Güvenlik Yöneticisi etkinleştirildiğinde, güvenlik politikasının bu izinleri Aspose.Slides JAR dosyasına ve onu çağıran uygulama koduna vermesi gerekir:

- `java.util.PropertyPermission "*", "read"`: Aspose.Slides sistem özelliklerini okur.
- `java.io.FilePermission "<<ALL FILES>>", "read"`: Aspose.Slides yazı tipi dosyalarını ve diğer dosyaları okur.
- `java.io.FilePermission "<<ALL FILES>>", "execute"`: Aspose.Slides işletim sistemi programlarını başlatır, örneğin Windows'ta `reg` ve Linux'ta `fc-match`.
- `java.io.FilePermission` ile `write` eylemi, uygulamanızın dosyaları kaydettiği klasörler için.

İzinleri sadece JAR dosyasına vermek yeterli değildir: Aspose.Slides'ı çağıran kod da bu izinlere ihtiyaç duyar. Her ikisine de `java.security.AllPermission` vermek de çalışır.

Sistem özelliklerini okuma veya program başlatma izni olmadan, Aspose.Slides ilk kullanımda başarısız olur: bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) nesnesi oluşturmak `ExceptionInInitializerError` hatası fırlatır. Yazı tipi dosyalarına okuma erişimi olmadan, bir sunumu PDF olarak kaydetmek “Cannot find any fonts installed on the system” hatasıyla başarısız olur.

## **Java 24 ve Sonrası**

Java 24 ve sonrasında Güvenlik Yöneticisi etkinleştirilemez, bu nedenle verilecek izin yoktur. Aspose.Slides, uygulamanızı çalıştıran hesabın izinleriyle çalışır. Bir uygulamanın neye erişebileceğini kısıtlamak için OpenJDK projesi, JDK dışındaki teknolojileri, örneğin konteynerler, hipervizörler ve işletim sistemi sandbox özelliklerini önerir. Bakınız [JEP 486](https://openjdk.org/jeps/486).

## **SSS**

**Kısıtlayıcı bir Güvenlik Yöneticisi politikasına sahip bir ortamda Aspose.Slides'ı kullanabilir miyim?**

Yalnızca politika, yukarıda listelenen izinleri hem Aspose.Slides'a hem de onu çağıran koda verdiği takdirde. Bu izinler, tüm dosyaları okuma ve herhangi bir programı başlatma iznini içerir.