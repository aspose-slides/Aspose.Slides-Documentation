---
title: Установка
type: docs
weight: 70
url: /ru/php-java/installation/
keywords:
- установить Aspose.Slides
- загрузить Aspose.Slides
- использовать Aspose.Slides
- установка Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Быстрая установка Aspose.Slides for PHP via Java. Пошаговое руководство, системные требования и примеры кода — начните работать с презентациями PowerPoint уже сегодня!"
---

## **Настройка среды**

1. Установите PHP 7, добавьте путь к PHP в системную переменную `PATH` и включите `allow_url_include` (установите `On`) в файле `php.ini`.
1. Установите JRE 8. Задайте переменную среды `JAVA_HOME`, указывающую путь к установленному JRE.
1. Установите Apache Tomcat 8.0.

## **Скачать Aspose.Slides for PHP via Java** 

`packagist` – самый простой способ получить [Aspose.Slides for PHP via Java](https://packagist.org/packages/aspose/slides). 

Чтобы установить Aspose.Slides через Packagist, выполните следующую команду: 
   ```bash
   composer require aspose/slides
   ```


## **Настройка Apache Tomcat**

1. Скачайте PHP/Java Bridge (`php-java-bridge_x.x.x_documentation.zip`) с http://php-java-bridge.sourceforge.net/pjb/download.php и распакуйте файл `JavaBridge.war` в папку `webapps` Tomcat.
1. Запустите службу Apache Tomcat.
1. Скачайте [“Aspose.Slides for PHP via Java”](https://downloads.aspose.com/slides/php-java) и распакуйте его в папку `aspose.slides`. Скопируйте файл `jar/aspose-slides-x.x-php.jar` в папку `webapps\JavaBridge\WEB-INF\lib`. Если вы используете **PHP 8**, замените оригинальный `Java.inc` из PHP‑Java Bridge на `Java.inc` из `Java.inc.php8.zip`.
1. Перезапустите службу Apache Tomcat.
1. Запустите `example.php` из папки `aspose.slides`, используя следующую команду: 
   ```bash
   php example.php
   ```


## **FAQ**

**Как проверить, что Aspose.Slides интегрирован правильно?**

Соберите проект, создайте пустой объект [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) и сохраните его под новым именем. Если файл создаётся без исключений, библиотека успешно интегрирована.

**Как ограничить потребление памяти при обработке крупных презентаций?**

Увеличивайте ограничения памяти JVM только столько, сколько действительно необходимо, и закрывайте каждый объект [Presentation] в блоке `finally`, чтобы оперативно освобождать кеш. Это предотвращает ошибки Out‑of‑Memory и делает использование памяти предсказуемым при пакетных операциях.

**Можно ли исключить ненужные форматы экспорта, чтобы уменьшить размер итогового JAR?**

Текущие версии Aspose.Slides поставляются в виде единой монолитной библиотеки, поэтому отключить отдельные экспортеры, такие как PDF или SVG, на этапе сборки нельзя.