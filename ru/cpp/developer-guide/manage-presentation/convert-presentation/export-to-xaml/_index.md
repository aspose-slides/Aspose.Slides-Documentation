---
title: Экспорт презентаций в XAML на C++
linktitle: Презентация в XAML
type: docs
weight: 30
url: /ru/cpp/export-to-xaml/
keywords:
- экспорт PowerPoint
- экспорт OpenDocument
- экспорт презентации
- преобразовать PowerPoint
- преобразовать OpenDocument
- преобразовать презентацию
- PowerPoint в XAML
- OpenDocument в XAML
- презентация в XAML
- PPT в XAML
- PPTX в XAML
- ODP в XAML
- сохранить PPT как XAML
- сохранить PPTX как XAML
- сохранить ODP как XAML
- экспорт PPT в XAML
- экспорт PPTX в XAML
- экспорт ODP в XAML
- C++
- Aspose.Slides
description: "Конвертируйте слайды PowerPoint и OpenDocument в XAML на C++ с помощью Aspose.Slides — быстрое решение без Office, сохраняющее ваш макет неизменным."
---

## **Экспорт презентаций в XAML**

{{% alert color="primary" %}} 

В [Aspose.Slides 21.6](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-6-release-notes/) реализована поддержка экспорта в XAML. Теперь вы можете экспортировать свои презентации в XAML. 

{{% /alert %}} 

## **Об XAML**

XAML — это описательный язык программирования, позволяющий создавать или описывать пользовательские интерфейсы для приложений, особенно тех, которые используют WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) и Xamarin Forms.  

XAML, основанный на XML, является вариантом Microsoft для описания графического интерфейса. Обычно вы работаете с файлами XAML в визуальном дизайнере, но при необходимости можете писать и редактировать разметку вручную. 

## **Экспорт презентаций в XAML с параметрами по умолчанию**

Этот C++‑код демонстрирует, как экспортировать презентацию в XAML с настройками по умолчанию:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```


## **Экспорт презентаций в XAML с пользовательскими параметрами**

Вы можете выбирать параметры из интерфейса [IXamlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options), которые управляют процессом экспорта и определяют, как Aspose.Slides будет экспортировать вашу презентацию в XAML. 

Например, если вы хотите, чтобы Aspose.Slides добавлял скрытые слайды вашей презентации при экспорте в XAML, передайте значение **true** методу [set_ExportHiddenSlides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313). Смотрите пример кода на C++: 
``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```


## **Часто задаваемые вопросы**

**Как гарантировать предсказуемый шрифт, если оригинальный шрифт недоступен на машине?**

Используйте [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) в [XamlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/) — он применяется как запасной шрифт, когда оригинальный отсутствует. Это помогает избежать неожиданных замен.

**Экспортируемый XAML предназначен только для WPF или его можно использовать в других стековых технологиях XAML?**

XAML — общий язык разметки пользовательского интерфейса, используемый в WPF, UWP и Xamarin.Forms. Экспорт ориентирован на совместимость со стековыми технологиями Microsoft XAML; конкретное поведение и поддержка определённых конструкций зависят от целевой платформы. Проверьте разметку в своей среде.

**Поддерживаются ли скрытые слайды и как можно отключить их экспорт по умолчанию?**

По умолчанию скрытые слайды не включаются. Управлять этим можно с помощью [set_ExportHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) в [XamlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/) — оставьте параметр отключённым, если экспорт скрытых слайдов не нужен.