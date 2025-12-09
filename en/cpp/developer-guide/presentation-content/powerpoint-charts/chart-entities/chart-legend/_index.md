---
title: Customize Chart Legends in Presentations Using С++
linktitle: Chart Legend
type: docs
url: /cpp/chart-legend/
keywords:
- chart legend
- legend position
- font size
- PowerPoint
- presentation
- С++
- Aspose.Slides
description: "Customize chart legends with Aspose.Slides for С++ to optimize PowerPoint presentations with tailored legend formatting."
---

## **Legend Positioning**
In order to set the legend properties. Please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
- Get the reference of the slide.
- Adding a chart on slide.
- Setting the properties of legend.
- Write the presentation as a PPTX file.

In the example given below, we have set the position and size for Chart legend.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}


## **Set the Font Size of a Legend**
The Aspose.Slides for C++ lets developers allow to set the font size of the legend. Please follow the steps below: 

- Instantiate Presentation class.
- Creating the default chart.
- Set the Font Size.
- Set minimum axis value.
- Set maximum axis value.
- Write a presentation to disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}




## **Set the Font Size of an Individual Legend**
The Aspose.Slides for C++ lets developers allow to set the font size of individual legend entries. Please follow the steps below: 

- Instantiate Presentation class.
- Creating the default chart.
- Access legend entry.
- Set the Font Size.
- Set minimum axis value.
- Set maximum axis value.
- Write a presentation to disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **FAQ**

**Can I enable the legend so that the chart automatically allocates space for it instead of overlaying it?**

Yes. Use the non-overlay mode ([set_Overlay(false)](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_overlay/)); in this case, the plot area will shrink to accommodate the legend.

**Can I make multi-line legend labels?**

Yes. Long labels wrap automatically when space is insufficient; forced line breaks are supported via newline characters in the series name.

**How do I make the legend follow the presentation theme’s color scheme?**

Do not set explicit colors/fills/fonts for the legend or its text. They will then inherit from the theme and update correctly when the design changes.
