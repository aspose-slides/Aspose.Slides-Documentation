---
title: Экспорт математических уравнений из презентаций на C++
linktitle: Экспорт уравнений
type: docs
weight: 30
url: /ru/cpp/exporting-math-equations/
keywords:
- экспорт математических уравнений
- экспорт уравнений в LaTeX
- PowerPoint в LaTeX
- MathML
- LaTeX
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Экспортируйте математические уравнения из презентаций PowerPoint в LaTeX или MathML напрямую с помощью Aspose.Slides для C++."
---
## **Введение**

Aspose.Slides for C++ позволяет экспортировать математические уравнения из презентаций. Например, вам может потребоваться извлечь математические уравнения со слайдов (из конкретной презентации) и использовать их в другой программе или платформе. 

{{% alert color="primary" %}} 
Вы можете экспортировать уравнения напрямую в LaTeX или в MathML — популярный стандарт математического контента, используемый в интернете и во многих приложениях.
{{% /alert %}}

## **Экспорт математических уравнений в LaTeX**

Aspose.Slides может преобразовать математическое уравнение PowerPoint напрямую в LaTeX; промежуточный файл MathML и внешний конвертер не требуются. Математическое уравнение хранится в текстовом фрейме как [IMathPortion](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/imathportion/). Используйте [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) чтобы получить [IMathParagraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/imathparagraph/), а затем вызовите [IMathParagraph::ToLatex](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/imathparagraph/tolatex/). Метод возвращает строку, которую можно сохранить, отобразить, отправить в другое приложение или далее обработать.

В следующем примере рассматриваются все текстовые фреймы на каждом слайде, находятся все математические части и каждая формула записывается в отдельный файл `.tex`:

```cpp
auto presentation = MakeObject<Presentation>(u"equations.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    int slideNumber = slideIndex + 1;
    int equationNumber = 1;
    auto textFrames = SlideUtil::GetAllTextBoxes(slide);

    for (const auto&& textFrame : textFrames)
    {
        for (const auto&& paragraph : textFrame->get_Paragraphs())
        {
            for (const auto&& portion : paragraph->get_Portions())
            {
                auto mathPortion = System::AsCast<IMathPortion>(portion);
                if (mathPortion == nullptr)
                    continue;

                auto mathParagraph = mathPortion->get_MathParagraph();
                auto latexPath = String::Format(u"slide_{0}_equation_{1}.tex", slideNumber, equationNumber);

                auto latexText = mathParagraph->ToLatex();
                File::WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}

presentation->Dispose();
```

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/ru/cpp/aspose.slides.util/slideutil/getalltextboxes/) возвращает все текстовые фреймы, найденные на слайде. Проверка типа [IMathPortion](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/imathportion/) отделяет настоящие редактируемые уравнения от обычного текста и изображений.

LaTeX‑движки и шаблоны документов не поддерживают одинаковый набор команд, пакетов или символов Unicode. Проверьте полученную строку с тем LaTeX‑движком, который используется в вашем приложении. Если символ или элемент Office Math не имеют подходящего представления в этой среде, замените его в полученной строке командой, специфичной для проекта, либо пропустите уравнение и зафиксируйте проблему для последующего рассмотрения.

## **Сохранение математических уравнений в формате MathML**

Хотя людям легко писать код для некоторых форматов уравнений, таких как LaTeX, им трудно писать код для MathML, поскольку последний предназначен для автоматической генерации приложениями. Программы легко читают и разбирают MathML, так как его код находится в XML, поэтому MathML часто используется как формат вывода и печати во многих областях. 

Этот пример кода показывает, как экспортировать математическое уравнение из презентации в MathML:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 500.0f, 50.0f);
auto mathPortion = System::ExplicitCast<IMathPortion>(autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0));
auto mathParagraph = mathPortion->get_MathParagraph();

mathParagraph->Add(System::MakeObject<MathematicalText>(u"a")
        - >SetSuperscript(u"2")
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"b")
                - >SetSuperscript(u"2"))
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"c")
                - >SetSuperscript(u"2")));

SharedPtr<Stream> stream = System::MakeObject<FileStream>(u"mathml.xml", FileMode::Create);

mathParagraph->WriteAsMathMl(stream);
```

## **Часто задаваемые вопросы**

**Что именно экспортируется в MathML — целый абзац или отдельный блок формулы?**

Вы можете экспортировать либо целый математический абзац ([MathParagraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/mathparagraph/)), либо отдельный блок ([MathBlock](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/mathblock/)) в MathML. Оба типа предоставляют метод для записи в MathML.

**Как определить, что объект на слайде является математической формулой, а не обычным текстом или изображением?**

Формула находится в [MathPortion](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/mathportion/) и имеет [MathParagraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/mathparagraph/). Изображения и обычные текстовые части без [MathParagraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/mathparagraph/) не являются экспортируемыми формулами.

**Откуда берется MathML в презентации — это специфично для PowerPoint или это стандарт?**

Экспорт ориентирован на стандартный MathML (XML). Aspose использует Presentation MathML — подмножество стандарта, предназначенное для презентаций, которое широко применяется в различных приложениях и в интернете.

**Поддерживается ли экспорт формул внутри таблиц, SmartArt, групп и т.д.?**

Да, если эти объекты содержат текстовые части с [MathParagraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides.mathtext/mathparagraph/) (т.е. настоящие формулы PowerPoint), они экспортируются. Если формула внедрена как изображение, она не экспортируется.

**Изменяет ли экспорт в MathML оригинальную презентацию?**

Нет. Запись MathML — это сериализация содержимого формулы; она не изменяет файл презентации.