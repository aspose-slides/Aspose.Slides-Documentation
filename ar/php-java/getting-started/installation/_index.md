---
title: التثبيت
type: docs
weight: 70
url: /ar/php-java/installation/
keySlides: "تحميل Aspose.Slides، تثبيت Aspose.Slides، تثبيت Aspose.Slides، ويندوز، macOS، لينكس، PHP"
description: "تثبيت Aspose.Slides لـ PHP عبر Java في ويندوز، لينكس أو macOS"
---

## **تهيئة البيئة**

1. قم بتثبيت PHP 7، أضف مسار PHP إلى المتغير `PATH` في النظام واضبط `allow_url_include` على `On` في ملف `php.ini`.
2. قم بتثبيت JRE 8. اضبط متغير البيئة `JAVA_HOME` على مسار JRE المثبت.
3. قم بتثبيت Apache Tomcat 8.0.

## **تحميل Aspose.Slides لـ PHP عبر Java** 

`packagist` هو أسهل طريقة لتحميل [Aspose.Slides لـ PHP عبر Java](https://packagist.org/packages/aspose/slides). 

لتثبيت Aspose.Slides باستخدام Packagist، قم بتنفيذ الأمر التالي: 
   ```bash
   composer require aspose/slides
   ```

## **تهيئة Apache Tomcat**

1. قم بتحميل PHP/Java Bridge (`php-java-bridge_x.x.x_documentation.zip`) من http://php-java-bridge.sourceforge.net/pjb/download.php واستخرج ملف `JavaBridge.war` إلى مجلد `webapps` الخاص بـ tomcat.
2. ابدأ خدمة Apache Tomcat.
3. قم بتحميل [“Aspose.Slides لـ PHP عبر Java”](https://downloads.aspose.com/slides/php-java) واستخرجها إلى مجلد `aspose.slides`. انسخ ملف `jar/aspose-slides-x.x-php.jar` إلى مجلد `webapps\JavaBridge\WEB-INF\lib`. إذا كنت تستخدم **PHP 8**، استبدل `Java.inc` الأصلية من PHP-Java Bridge بـ `Java.inc` من `Java.inc.php8.zip`.
4. أعد تشغيل خدمة Apache Tomcat.
5. قم بتشغيل `example.php` في مجلد `aspose.slides` لتشغيل المثال باستخدام هذا الأمر:
   ```bash
   php example.php
   ```

## إعداد Docker ##

المتطلبات الأساسية:
* قم بتثبيت Docker على جهازك. يمكنك اتباع دليل التثبيت الرسمي [هنا](https://docs.docker.com/get-docker/).

الخطوات:
1. **إنشاء Dockerfile**. أنشئ ملفًا جديدًا باسم Dockerfile في مسار مشروعك بالمحتوى التالي:
   ```
   # الصورة الأساسية (الصورة الرسمية لـ Ubuntu)
   FROM ubuntu:20.04
   
   # ضبط المنطقة الزمنية مسبقًا لتجنب الاختيار التفاعلي
   ENV DEBIAN_FRONTEND=noninteractive
   RUN ln -fs /usr/share/zoneinfo/Europe/Berlin /etc/localtime && \
       apt-get update && apt-get install -y tzdata && \
       dpkg-reconfigure --frontend noninteractive tzdata
   
   # تثبيت الحزم الضرورية وتحديث قوائم الحزم
   RUN apt-get install -y \
       wget \
       curl \
       apt-transport-https \
       ca-certificates \
       software-properties-common \
       php-cli \
       php-cgi \
       libapache2-mod-php \
       unzip \
       openjdk-8-jdk \
       debconf \
       && rm -rf /var/lib/apt/lists/*
   
   # قبول اتفاقية الترخيص تلقائيًا لتثبيت خطوط Microsoft TrueType
   RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections
   
   # تثبيت خطوط Microsoft TrueType
   RUN apt-get update && \
       apt-get install -y ttf-mscorefonts-installer && \
       rm -rf /var/lib/apt/lists/*
   
   # تثبيت Tomcat - باستخدام الإصدار 9.0.93
   RUN wget https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.93/bin/apache-tomcat-9.0.93.tar.gz -O /tmp/tomcat.tar.gz && \
       tar xzf /tmp/tomcat.tar.gz -C /opt/ && \
       mv /opt/apache-tomcat-9.0.93 /opt/tomcat && \
       rm /tmp/tomcat.tar.gz
   
   # تثبيت PHP/Java Bridge
   RUN curl -L http://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download -o /tmp/php-java-bridge.zip && \
       unzip /tmp/php-java-bridge.zip -d /tmp/php-java-bridge && \
       mkdir -p /opt/tomcat/webapps/JavaBridge && \
       cp /tmp/php-java-bridge/JavaBridge.war /opt/tomcat/webapps/JavaBridge && \
       cd /opt/tomcat/webapps/JavaBridge && \
       jar -xvf JavaBridge.war && \
       rm -rf /tmp/php-java-bridge.zip /tmp/php-java-bridge
   
   # تحميل وتثبيت Aspose.Slides لـ PHP عبر Java
   RUN wget https://github.com/aspose-slides/Aspose.Slides-for-PHP-via-Java/archive/refs/heads/master.zip -O /tmp/aspose-slides.zip && \
       unzip /tmp/aspose-slides.zip -d /tmp/aspose-slides && \
       mkdir -p /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       mkdir -p /tmp/sample && \
       cp /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/jar/*.jar /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       cp -r /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/lib /tmp/sample && \
       rm -rf /tmp/aspose-slides.zip /tmp/aspose-slides
   
   # إنشاء ملف test.php
   RUN echo '<?php\n\
   require_once("http://localhost:8080/JavaBridge/java/Java.inc");\n\
   require_once("lib/aspose.slides.php");\n\n\
   use aspose\\slides\\Presentation;\n\
   use aspose\\slides\\ShapeType;\n\
   use aspose\\slides\\SaveFormat;\n\
   use aspose\\slides\\License;\n\n\
   $license = new License();\n\n\
   $presentation = new Presentation();\n\
   $slide = $presentation->getSlides()->get_Item(0);\n\
   $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);\n\
   $presentation->save("output.pdf", SaveFormat::Pdf);\n\n\
   ?>' > /tmp/sample/test.php
   
   # إنشاء سكربت entrypoint.sh
   RUN echo '#!/bin/bash\n\
   # بدء Tomcat في الخلفية\n\
   catalina.sh start\n\
   # الانتظار حتى يبدأ Tomcat بالكامل\n\
   until curl -s http://localhost:8080 > /dev/null; do\n\
    sleep 2\n\
   done\n\
   echo "تشغيل السكربت PHP..."\n\
   # تشغيل سكربت PHP\n\
   php /tmp/sample/test.php\n\
   echo "اكتمل سكربت PHP، يرجى التحقق من الملف /tmp/output.pdf."\n\
   # إبقاء الحاوية نشطة\n\
   echo "إبقاء الحاوية نشطة..."\n\
   tail -f /dev/null\n\
   ' > /tmp/entrypoint.sh
   
   # منح الأذونات التنفيذية للسكربت
   RUN chmod 755 /tmp/entrypoint.sh
   
   # تكوين php.ini
   RUN echo "allow_url_include = On" >> /etc/php/7.4/cli/php.ini
   
   # ضبط متغيرات البيئة لـ Tomcat
   ENV CATALINA_HOME /opt/tomcat
   ENV PATH $CATALINA_HOME/bin:$PATH
   ENV PHP_CLASSPATH /opt/aspose-slides/lib
   
   # فتح المنفذ 8080 لـ Tomcat والport 9000 لـ PHP/Java Bridge
   EXPOSE 8080
   EXPOSE 9000
   
   # تعيين دليل العمل
   WORKDIR /tmp
   
   # بدء Tomcat عند بدء الحاوية
   ENTRYPOINT ["/tmp/entrypoint.sh"]
   ```

2. **بناء صورة Docker**. قم بتشغيل الأمر التالي في الدليل حيث يوجد Dockerfile لديك لبناء صورة Docker:
   ```bash
   docker build -t aspose-slides-php-java .
   ```

3. **تشغيل حاوية Docker**. بعد بناء الصورة، قم بتشغيل الحاوية:
   ```bash
   docker run -p 8080:8080 aspose-slides-php-java
   ```

4. **الوصول إلى Aspose.Slides في Docker**. بعد بدء الحاوية، سيقوم السكربت بإنشاء ملف PDF. يمكنك العثور على ملف الخروج الناتج `output.pdf` في مجلد `/tmp` داخل الحاوية:
   ```bash
   docker exec -it <container-id> ls /tmp
   ```
   لنسخ ملف PDF الناتج إلى جهازك المحلي، قم بتنفيذ الأمر التالي:
   ```bash
   docker cp <container-id>:/tmp/output.pdf ./output.pdf
   ```