---
title: Публичный API и изменения, несовместимые с предыдущими версиями, в Aspose.Slides для PHP через Java 14.8.0
type: docs
weight: 70
url: /ru/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) классы, методы, свойства и так далее, любые новые ограничения и другие [изменения](/slides/ru/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) введенные в API Aspose.Slides для PHP через Java 14.8.0.

{{% /alert %}} 
## **Изменения в публичном API**
### **Добавлены методы Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap() и setOverlap(byte)**
Метод Aspose.Slides.Charts.IChartSeries.getOverlap() возвращает, насколько бары и столбцы должны накладываться на 2D графиках (в диапазоне от -100 до 100).
Этот метод относится не только к конкретной серии, но и ко всем сериям родительской группы серий - это проекция соответствующего свойства группы.

- Используйте метод IChartSeries.getParentSeriesGroup() для доступа к родительской группе серий.
- Используйте методы IChartSeriesGroup.getOverlap() и setOverlap(byte) для управления значением.

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
  $series = $chart->getChartData()->getSeries();
  if (java_values($series->get_Item(0)->getOverlap()) == 0) {
    $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
  }
```
### **Добавлено значение Enum ShapeThumbnailBounds.Appearance**
Этот метод создания миниатюр фигур позволяет разработчикам генерировать миниатюры фигур в пределах их внешнего вида. Он учитывает все эффекты фигуры. Сгенерированная миниатюра фигуры ограничена границами слайда.

```php
  $pres = new Presentation();
  $st = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThumbnail(ShapeThumbnailBounds->Appearance, 1, 1);
```
### **Добавлены класс VbaProject и интерфейс IVbaProject, изменены методы Presentation.getVbaProject() и setVbaProject(VbaProject)**
Новая функция позволяет разработчикам создавать и редактировать VBA проекты в презентации.

```php
  $pres = new Presentation();
  # Создать новый VBA проект
  $pres->setVbaProject(new VbaProject());
  # Добавить пустой модуль в VBA проект
  $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
  # Установить исходный код модуля
  $module->setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");
  # Создать ссылку на <stdole>
  $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
  # Создать ссылку на Office
  $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Библиотека объектов Microsoft Office 14.0");
  # Добавить ссылки в VBA проект
  $pres->getVbaProject()->getReferences()->add($stdoleReference);
  $pres->getVbaProject()->getReferences()->add($officeReference);
  $pres->save("data\\test.pptm", SaveFormat::Pptm);
```