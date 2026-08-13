---
title: Demo Kurulumu
type: docs
weight: 70
url: /tr/jasperreports/demos-setup/
---
Aspose.Slides for JasperReports ile sağlanan tüm demolar değiştirilmiş standart demolardır. Tüm demoları JasperReports demo klasörüne kopyalamanız daha iyidir:
...\jasperreports-x.x.x\demo\samples\

Raporları derlemek ve dışa aktarmak için standart komut sırasını kullanın:

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="info" %}} 

Lütfen raporları veriyle doldurmak için test veritabanıyla HSQLDB'yi çalıştırmayı ve aspose.slides.jasperreports.library-xx.x.jar dosyasını aspose-slides-xx.x-jasperreports.zip içindeki \lib\JasperReports X.X.X - X.X.X klasöründen &#60;InstallDir&#62;\lib dizinine kopyalamayı unutmayın.

{{% /alert %}} 

Çoğu demo (Charts dışındakiler) zaten oluşturulmuş sunumlara sahiptir, bu nedenle tüm “ant” adımlarını atlayabilir ve sonuçları hemen kontrol edebilirsiniz.