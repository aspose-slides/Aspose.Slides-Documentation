---
title: Docker का उपयोग करके Java के माध्यम से PHP के लिए Aspose.Slides स्थापित करें
type: docs
weight: 75
url: /hi/php-java/installing-slides-php-using-docker/
keywords:
- Aspose.Slides डाउनलोड करें
- Aspose.Slides स्थापित करें
- Aspose.Slides स्थापना
- Docker
- Windows
- macOS
- Linux
- क्रॉस-प्लेटफ़ॉर्म संगतता
- निर्भरता पृथक्करण
- सरलीकृत परिनियोजन
- परियोजना सेटअप
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- PHP
- Aspose.Slides
description: "Docker कंटेनरों में Aspose.Slides चलाएँ: इमेज, निर्भरताएँ, फ़ॉन्ट और लाइसेंसिंग को कॉन्फ़िगर करके स्केलेबल सेवाएँ बनाएं जो PowerPoint और OpenDocument प्रोसेस करती हैं।"
---
## **पूर्व आवश्यकताएँ**
* अपने मशीन पर Docker स्थापित करें। आप आधिकारिक स्थापना गाइड [यहाँ](https://docs.docker.com/get-docker/) का पालन कर सकते हैं।

## **चरण**

### **1. Dockerfile बनाएं** 
   अपने प्रोजेक्ट डायरेक्टरी में Dockerfile नाम की नई फ़ाइल बनाएं, जिसमें निम्नलिखित सामग्री हो:
   ```
   # बेस इमेज (आधिकारिक Ubuntu इमेज)
   FROM ubuntu:20.04
   
   # इंटरैक्टिव चयन से बचने के लिए समय क्षेत्र पहले सेट करें
   ENV DEBIAN_FRONTEND=noninteractive
   RUN ln -fs /usr/share/zoneinfo/Europe/Berlin /etc/localtime && \
       apt-get update && apt-get install -y tzdata && \
       dpkg-reconfigure --frontend noninteractive tzdata
   
   # आवश्यक पैकेज स्थापित करें और पैकेज सूचियों को अपडेट करें
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
   
   # Microsoft TrueType फ़ॉन्ट स्थापित करने के लिए लाइसेंस समझौते को स्वचालित रूप से स्वीकार करें
   RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections
   
   # Microsoft TrueType फ़ॉन्ट स्थापित करें
   RUN apt-get update && \
       apt-get install -y ttf-mscorefonts-installer && \
       rm -rf /var/lib/apt/lists/*
   
   # Tomcat स्थापित करें - संस्करण 9.0.93 का उपयोग करके
   RUN wget https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.93/bin/apache-tomcat-9.0.93.tar.gz -O /tmp/tomcat.tar.gz && \
       tar xzf /tmp/tomcat.tar.gz -C /opt/ && \
       mv /opt/apache-tomcat-9.0.93 /opt/tomcat && \
       rm /tmp/tomcat.tar.gz
   
   # PHP/Java ब्रिज स्थापित करें
   RUN curl -L http://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download -o /tmp/php-java-bridge.zip && \
       unzip /tmp/php-java-bridge.zip -d /tmp/php-java-bridge && \
       mkdir -p /opt/tomcat/webapps/JavaBridge && \
       cp /tmp/php-java-bridge/JavaBridge.war /opt/tomcat/webapps/JavaBridge && \
       cd /opt/tomcat/webapps/JavaBridge && \
       jar -xvf JavaBridge.war && \
       rm -rf /tmp/php-java-bridge.zip /tmp/php-java-bridge
   
   # Aspose.Slides for PHP via Java डाउनलोड और स्थापित करें
   RUN wget https://github.com/aspose-slides/Aspose.Slides-for-PHP-via-Java/archive/refs/heads/master.zip -O /tmp/aspose-slides.zip && \
       unzip /tmp/aspose-slides.zip -d /tmp/aspose-slides && \
       mkdir -p /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       mkdir -p /tmp/sample && \
       cp /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/jar/*.jar /opt/tomcat/webapps/JavaBridge/WEB-INF/lib && \
       cp -r /tmp/aspose-slides/Aspose.Slides-for-PHP-via-Java-master/lib /tmp/sample && \
       rm -rf /tmp/aspose-slides.zip /tmp/aspose-slides
   
   # test.php फ़ाइल बनाएं
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
   
   # entrypoint.sh स्क्रिप्ट बनाएं
   RUN echo '#!/bin/bash\n\
   # बैकग्राउंड में Tomcat शुरू करें\n\
   catalina.sh start\n\
   # Tomcat के पूरी तरह शुरू होने की प्रतीक्षा करें\n\
   until curl -s http://localhost:8080 > /dev/null; do\n\
    sleep 2\n\
   done\n\
   echo "Running the PHP script..."\n\
   # PHP स्क्रिप्ट चलाएँ\n\
   php /tmp/sample/test.php\n\
   echo "PHP script completed, please check file /tmp/output.pdf."\n\
   # कंटेनर को जीवित रखें\n\
   echo "Keeping the container alive..."\n\
   tail -f /dev/null\n\
   ' > /tmp/entrypoint.sh
   
   # स्क्रिप्ट को स्पष्ट रूप से निष्पादन अनुमति दें
   RUN chmod 755 /tmp/entrypoint.sh
   
   # php.ini कॉन्फ़िगर करें
   RUN echo "allow_url_include = On" >> /etc/php/7.4/cli/php.ini
   
   # Tomcat के लिए पर्यावरण चर सेट करें
   ENV CATALINA_HOME /opt/tomcat
   ENV PATH $CATALINA_HOME/bin:$PATH
   ENV PHP_CLASSPATH /opt/aspose-slides/lib
   
   # Tomcat के लिए पोर्ट 8080 और PHP/Java ब्रिज के लिए पोर्ट 9000 को उजागर करें
   EXPOSE 8080
   EXPOSE 9000
   
   # वर्किंग डायरेक्टरी सेट करें
   WORKDIR /tmp
   
   # कंटेनर शुरू होने पर Tomcat शुरू करें
   ENTRYPOINT ["/tmp/entrypoint.sh"]
```

### **2. Docker इमेज बनाएं**
   Dockerfile स्थित डायरेक्टरी में निम्न कमांड चलाएँ ताकि Docker इमेज बन सके:
   ```bash
   docker build -t aspose-slides-php-java .
   ```

### **3. Docker कंटेनर चलाएँ**
   इमेज बन जाने के बाद, कंटेनर चलाएँ:
   ```bash
   docker run -p 8080:8080 aspose-slides-php-java
   ```

### 4. **Docker में Aspose.Slides तक पहुंचें** 
   कंटेनर शुरू करने के बाद, स्क्रिप्ट एक PDF फ़ाइल बनाएगी। आप उत्पन्न आउटपुट फ़ाइल `output.pdf` कंटेनर के अंदर `/tmp` फ़ोल्डर में पा सकते हैं:
   ```bash
   docker exec -it <container-id> ls /tmp
   ```
   जनरेट की गई PDF फ़ाइल को अपने स्थानीय मशीन पर कॉपी करने के लिए, निम्न कमांड चलाएँ:
   ```bash
   docker cp <container-id>:/tmp/output.pdf ./output.pdf
   ```