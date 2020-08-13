---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for .NET 14.3.0
type: docs
weight: 50
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
---

## **Public API and Backwards Incompatible Changes**
#### **Aspose.Slides.ShapeThumbnailBounds Enumeration and Aspose.Slides.IShape.GetThumbnail() Methods Added**
The methods GetThumbnail() and GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) are used to create a separate shape thumbnail. The ShapeThumbnailBounds enumeration defines the possible shape thumbnail bound types.
#### **Property UniqueId has been added to Aspose.Slides.IShape**
The Aspose.Slides.IShape.UniqueId property gets unique in a presentation scope shape identifier. These unique identifiers are stored in shape custom tags.
#### **Signature of the SetGroupingItem Method Changed in IChartCategoryLevelsManager**
Signature of the IChartCategoryLevelsManager method

{{< highlight java >}}

 void SetGroupingItem(int level, IChartDataCell value);

{{< /highlight >}}

is obsolete now and replaced with the signature

{{< highlight java >}}

 void SetGroupingItem(int level, object value);

{{< /highlight >}}

Now calls like

{{< highlight java >}}

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

{{< /highlight >}}

must be changed to calls like

{{< highlight java >}}

 .SetGroupingItem(1, "Group 1");

{{< /highlight >}}

Pass a value like "Group 1" into SetGroupingItem but not a value of type IChartDataCell. Constructing IChartDataCell with a defined worksheet, row and column for category levels must satisfy some requirements and has been encapsulated in the SetGroupingItem(int, object) method.
#### **SlideId Property Added to the Aspose.Slides.IBaseSlide Interface**
Property SlideId gets an unique slide identifier.
#### **SoundName Property Added to ISlideShowTransition**
Read-write string. Specifies a human readable name for the sound of the transition. The Sound property must be assigned to get or set the sound name. This name appears in the PowerPoint user interface when configuring the transition sound manually. May throw PptxException when the Sound property is not assigned.
#### **Type of ChartSeriesGroup.Type Property Changed**
The ChartSeriesGroup.Type property has been changed from the ChartType enumeration to the new CombinableSeriesTypesGroup enumeration. The CombinableSeriesTypesGroup enum represents the groups of combinable series types.
#### **Support for Generating Individual Shape Thumbnails Added**
Aspose.Slides.ShapeThumbnailBounds

New members in Aspose.Slides.IShape, Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)
