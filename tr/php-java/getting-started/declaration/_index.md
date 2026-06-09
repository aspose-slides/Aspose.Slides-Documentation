---
title: Deklarasyon
type: docs
weight: 60
url: /tr/php-java/declaration/
keywords:
- deklarasyon
- bileşenler
- Tam Güven izni
- kayıt defteri ayarları
- sistem dosyaları
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP güven gereksinimleri, izinler ve barındırma sınırlamaları hakkında bilgi edinin, böylece PPT, PPTX ve ODP işleyen uygulamaları sunuculara güvenli bir şekilde dağıtabileceksiniz."
---
{{% alert color="primary" %}} 

Tüm Aspose Java bileşenleri Tam Güven (Full Trust) izin kümesini gerektirir. Bunun nedeni, Aspose Java bileşenlerinin belirli işlemler (ör. yazı tipi ayrıştırma vb.) için kayıt defteri ayarlarına, sanal dizin dışındaki sistem dosyalarına erişmesi gerektiğidir. Ayrıca, Aspose Java Bileşenleri, birçok durumda Tam Güven izin kümesini gerektiren temel Java sistem sınıflarına dayanır. 

{{% /alert %}} 

Farklı şirketlerden birden çok uygulamayı barındıran İnternet Servis Sağlayıcıları genellikle Orta Güven (Medium Trust) güvenlik seviyesini uygular: 

- OleDbPermission mevcut değildir. Bu, ADO.NET yönetilen OLE DB veri sağlayıcısını kullanarak veritabanlarına erişemeyeceğiniz anlamına gelir.
- EventLogPermission mevcut değildir. Bu, Windows olay günlüğüne erişemeyeceğiniz anlamına gelir.
- ReflectionPermission mevcut değildir. Bu, yansıma (reflection) kullanamayacağınız anlamına gelir.
- RegistryPermission mevcut değildir. Bu, kayıt defterine erişemeyeceğiniz anlamına gelir.
- WebPermission kısıtlıdır. Bu, uygulamanızın yalnızca <trust> öğesinde tanımladığınız adres veya adres aralığıyla iletişim kurabileceği anlamına gelir.
- FileIOPermission kısıtlıdır. Bu, yalnızca uygulamanızın sanal dizin hiyerarşisindeki dosyalara erişebileceğiniz anlamına gelir.

{{% alert color="primary" %}} 

Yukarıda belirtilen nedenlerle, Aspose Java bileşenleri Tam Güven dışındaki izin kümesi verilen sunucularda kullanılamaz. 

{{% /alert %}}