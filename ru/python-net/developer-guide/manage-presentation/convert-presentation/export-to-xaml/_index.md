---
title: Экспорт презентаций в XAML с помощью Python
linktitle: Экспорт в XAML
type: docs
weight: 30
url: /ru/python-net/export-to-xaml/
keywords:
- экспорт PowerPoint
- экспорт OpenDocument
- экспорт презентации
- конвертация PowerPoint
- конвертация OpenDocument
- конвертация презентации
- PowerPoint в XAML
- OpenDocument в XAML
- презентация в XAML
- PPT в XAML
- PPTX в XAML
- ODP в XAML
- Python
- Aspose.Slides
description: "Конвертируйте слайды PowerPoint и OpenDocument в XAML с помощью Python и Aspose.Slides — быстрое решение без Office, сохраняющее оригинальное расположение элементов."
---

## **Обзор**

{{% alert title="Info" color="info" %}} 

В [Aspose.Slides 21.6](https://docs.aspose.com/slides/python-net/aspose-slides-for-net-21-6-release-notes/), мы реализовали поддержку экспорта в XAML. Теперь вы можете экспортировать свои презентации в XAML. 

{{% /alert %}} 

XAML — описательный язык программирования, позволяющий создавать или описывать пользовательские интерфейсы для приложений, особенно тех, которые используют WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) и Xamarin Forms.  

XAML, основанный на XML, является вариантом Microsoft для описания графического интерфейса. Обычно вы будете работать с XAML‑файлами через дизайнер, но при желании можете писать и редактировать интерфейс вручную. 

## **Экспорт презентаций в XAML с параметрами по умолчанию**

Этот код на Python показывает, как экспортировать презентацию в XAML с настройками по умолчанию:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```

## **Экспорт презентаций в XAML с пользовательскими параметрами**

Вы можете выбирать параметры из интерфейса [IXamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/ixamloptions/), которые управляют процессом экспорта и определяют, как Aspose.Slides экспортирует вашу презентацию в XAML. 

Например, если вы хотите, чтобы Aspose.Slides добавлял скрытые слайды из вашей презентации при экспорте в XAML, можно установить свойство [ExportHiddenSlides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/ixamloptions/) в значение true. См. пример кода на Python:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```

## **Часто задаваемые вопросы**

**Как обеспечить предсказуемый шрифт, если оригинальный шрифт недоступен на машине?**

Установите [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) в [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) — он будет использоваться в качестве резервного шрифта, когда оригинал отсутствует. Это помогает избежать неожиданной подстановки.

**Предназначен ли экспортированный XAML только для WPF, или его можно использовать и в других стэках XAML?**

XAML — общий язык разметки UI, используемый в WPF, UWP и Xamarin.Forms. Экспорт ориентирован на совместимость со стеками Microsoft XAML; точное поведение и поддержка конкретных конструкций зависят от целевой платформы. Протестируйте разметку в своей среде.

**Поддерживаются ли скрытые слайды и как предотвратить их экспорт по умолчанию?**

По умолчанию скрытые слайды не включаются. Этим можно управлять через [export_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) в [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) — оставьте его отключённым, если не требуется экспортировать скрытые слайды.