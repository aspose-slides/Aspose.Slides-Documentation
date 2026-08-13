---
title: Настройка демонстраций
type: docs
weight: 70
url: /ru/jasperreports/demos-setup/
---
Все демонстрационные примеры, поставляемые с Aspose.Slides for JasperReports, являются изменёнными стандартными демонстрациями. Рекомендуется скопировать все демонстрации в папку JasperReports demo:
...\jasperreports-x.x.x\demo\samples\

Используйте стандартную последовательность команд для сборки и экспорта отчётов:

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="info" %}} 

Пожалуйста, не забудьте запустить HSQLDB с тестовой базой данных, чтобы заполнить отчёты данными, и скопировать aspose.slides.jasperreports.library-xx.x.jar из папки \lib\JasperReports X.X.X - X.X.X архива aspose-slides-xx.x-jasperreports.zip в каталог &#60;InstallDir&#62;\lib.

{{% /alert %}} 

Большинство демонстраций (за исключением Charts) уже содержат сгенерированные презентации, поэтому вы можете пропустить все шаги «ant» и сразу проверить результаты.