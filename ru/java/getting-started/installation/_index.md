---
title: Установка
type: docs
weight: 70
url: /ru/java/installation/
---

{{% alert color="primary" %}} 

Aspose.Slides для Java не требует Microsoft PowerPoint. Он программно генерирует необходимые файлы презентаций. Однако, чтобы просмотреть сгенерированную презентацию, вам может понадобиться использовать PowerPoint или просмотрщик презентаций. 

{{% /alert %}} 

## **Установка и настройка Java**
Java — это популярный язык программирования, который позволяет запускать программы на многих платформах. 

Для получения информации о установке и настройке Java на любой операционной системе перейдите на https://java.com/.

## **Установка Aspose.Slides для Java из Maven репозитория**
Aspose размещает все Java API на [Maven репозиториях](https://releases.aspose.com/java/repo/com/aspose/). Вы можете использовать [Aspose.Slides для Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) API напрямую в ваших Maven проектах с простыми конфигурациями.

1. **Укажите конфигурацию репозитория Maven**

   Укажите конфигурацию/местоположение репозитория Aspose в вашем Maven pom.xml следующим образом:

``` xml
<repositories>
    <repository>
        <id>AsposeJavaAPI</id>
        <name>Aspose Java API</name>
        <url>https://releases.aspose.com/java/repo/</url>
    </repository>
</repositories>
```
2. **Определите зависимость Aspose.Slides для Java API**

   Определите зависимость Aspose.Slides для Java API в вашем pom.xml следующим образом:

``` xml
<dependencies>
    <dependency>
        <groupId>com.aspose</groupId>
        <artifactId>aspose-slides</artifactId>
        <version>XX.XX</version>
        <classifier>jdk16</classifier>
    </dependency>
    <dependency>
        <groupId>com.aspose</groupId>
        <artifactId>aspose-slides</artifactId>
        <version>XX.XX</version>
        <classifier>javadoc</classifier>
    </dependency>
</dependencies>
```

Зависимость Aspose.Slides для Java затем будет определена в вашем Maven проекте.