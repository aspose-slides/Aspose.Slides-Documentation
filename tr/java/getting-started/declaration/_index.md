---
title: Deklarasyon
type: docs
weight: 60
url: /tr/java/declaration/
keywords:
- deklarasyon
- bileşenler
- Full Trust izni
- kayıt defteri ayarları
- sistem dosyaları
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java güven gereksinimleri, izinler ve barındırma sınırlamaları hakkında bilgi edinin, böylece PPT, PPTX ve ODP işleyen uygulamaları sunucularda güvenle dağıtabilirsiniz."
---
{{% alert color="primary" %}} 

Tüm Aspose Java bileşenleri Full Trust izin kümesini gerektirir. Bunun nedeni, Aspose Java bileşenlerinin yazı tipi ayrıştırma gibi belirli işlemler için sanal dizin dışındaki kayıt defteri ayarlarına ve sistem dosyalarına erişmesi gerekir. Ayrıca, Aspose Java Bileşenleri, birçok durumda Full Trust izin kümesini gerektiren temel Java sistem sınıflarına dayanır. 

{{% /alert %}} 

Internet Service Providers hosting multiple applications from different companies mostly enforce Medium Trust security level: 

- OleDbPermission mevcut değil. Bu, veritabanlarına erişmek için ADO.NET yönetilen OLE DB veri sağlayıcısını kullanamayacağınız anlamına gelir.
- EventLogPermission mevcut değil. Bu, Windows olay günlüğüne erişemeyeceğiniz anlamına gelir.
- ReflectionPermission mevcut değil. Bu, yansıma kullanamayacağınız anlamına gelir.
- RegistryPermission mevcut değil. Bu, kayıt defterine erişemeyeceğiniz anlamına gelir.
- WebPermission kısıtlanmıştır. Bu, uygulamanızın yalnızca <trust> öğesinde tanımladığınız bir adres veya adres aralığıyla iletişim kurabileceği anlamına gelir.
- FileIOPermission kısıtlanmıştır. Bu, yalnızca uygulamanızın sanal dizin hiyerarşisindeki dosyalara erişebileceğiniz anlamına gelir.

{{% alert color="primary" %}} 

Yukarıda belirtilen nedenlerden dolayı, Aspose Java bileşenleri Full Trust dışındaki izin kümesini sağlayan sunucularda kullanılamaz. 

{{% /alert %}}