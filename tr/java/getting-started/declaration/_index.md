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
description: "Aspose.Slides for Java güven gereksinimlerini, izinlerini ve barındırma sınırlamalarını öğrenin, böylece PPT, PPTX ve ODP işleyen uygulamaları sunucularda güvenli bir şekilde dağıtabilirsiniz."
---
{{% alert color="info" %}} 

Tüm Aspose Java bileşenleri Full Trust izin kümesini gerektirir. Bunun nedeni, Aspose Java bileşenlerinin fontları ayrıştırma gibi belirli işlemler için kayıt defteri ayarlarına, sanal dizin dışındaki sistem dosyalarına erişmesi gerektiğidir. Ayrıca, Aspose Java Bileşenleri, birçok durumda Full Trust izin kümesini gerektiren temel Java sistem sınıflarına dayanır. 

{{% /alert %}} 

İnternet Servis Sağlayıcıları, farklı şirketlere ait birden fazla uygulamayı barındırırken genellikle Medium Trust güvenlik seviyesini uygular: 

- OleDbPermission mevcut değildir. Bu, veritabanlarına erişmek için ADO.NET yönetilen OLE DB veri sağlayıcısını kullanamayacağınız anlamına gelir.
- EventLogPermission mevcut değildir. Bu, Windows olay günlüğüne erişemeyeceğiniz anlamına gelir.
- ReflectionPermission mevcut değildir. Bu, yansıtma kullanamayacağınız anlamına gelir.
- RegistryPermission mevcut değildir. Bu, kayıt defterine erişemeyeceğiniz anlamına gelir.
- WebPermission kısıtlanmıştır. Bu, uygulamanızın yalnızca <trust> öğesinde tanımladığınız bir adres veya adres aralığıyla iletişim kurabileceği anlamına gelir.
- FileIOPermission kısıtlanmıştır. Bu, yalnızca uygulamanızın sanal dizin hiyerarşisindeki dosyalara erişebileceğiniz anlamına gelir.

{{% alert color="info" %}} 

Yukarıda belirtilen nedenlerden dolayı, Aspose Java bileşenleri Full Trust dışındaki bir izin kümesi veren sunucularda kullanılamaz. 

{{% /alert %}}