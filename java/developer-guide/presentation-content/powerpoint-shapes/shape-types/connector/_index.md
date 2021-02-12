---
title: Connector
type: docs
weight: 10
url: /java/connector/
---

##**Overview**
{{% alert color="primary" %}} 

Aspose.Slides for Java now supports connecting shapes using connectors layout. In this topic, we will see with example for how to connect two shapes using Connectors in Aspose.Slides.

{{% /alert %}} 

The connectors can be connected to shapes in two ways.


## **Connect Shapes using Connectors**
In order to add a connector shape for joining two shapes. Please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add two add AutoShape's in selected slide using AddAutoShape method exposed by Shapes object.
- Add Connector using **AddConnector** method exposed by Shapes object by defining Connector Type.
- Join the added shape using connectors.
- Write the presentation as a PPTX file.

In the example given below, we have added a connector between two shapes.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ConnectingShapesUsingConnectors-ConnectingShapesUsingConnectors.java" >}}

{{% alert color="primary" %}} 

Method com.aspose.slides.IConnector.reroute() reroutes connector so that it take the shortest possible path between the shapes it connect. To do this, the reroute() method may change the StartShapeConnectionSiteIndex and EndShapeConnectionSiteIndex.

{{% /alert %}} 

## **Connect Shapes with Desired Connection Site**
In order to add a connector shape for joining two shapes. Please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add two add AutoShape's in selected slide using AddAutoShape method exposed by Shapes object.
- Add Connector using **AddConnector** method exposed by Shapes object by defining Connector Type.
- Join the added shape using connectors.
- Setting the desired connection site on shape for connector.
- Write the presentation as a PPTX file.

In the example given below, we have added a connector between two shapes.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ConnectingShapeWithConnectorOnDesiredConnectionSite-ConnectingShapeWithConnectorOnDesiredConnectionSite.java" >}}

## **Find Angle of Connector Line**
In order to calculate the angle for connector line, please follow the steps below:

- Create an instance of [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class and load the presentation.
- Obtain the reference of a slide by using its Index.
- Access the Connector Line shape.
- Use the line width, height, shape frame height and shape frame width to calculate the angle.

In the example given below, we have calculated the angle for connector line shape in slide.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-ShapesNew-CalculatingConnectorLineAngle-.java" >}}
